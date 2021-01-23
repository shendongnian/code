    Imports System.Deployment.Application
    Imports System.ComponentModel
    
    Public Class UpdateChecker
    
        Public Enum UpdateType
            Automatic
            Manual
        End Enum
    
        Private Shared MyInstance As UpdateChecker
        Public Shared ReadOnly Property Current() As UpdateChecker
            Get
                If MyInstance Is Nothing Then
                    MyInstance = New UpdateChecker
                End If
                Return MyInstance
            End Get
        End Property
    
        Private WithEvents CurrDeployment As ApplicationDeployment
        Private CurrType As UpdateType
        Private _checking As Boolean = False
        Private _lastErrorSentOnCheck As DateTime?
    
        Public ReadOnly Property LastUpdateCheck() As DateTime?
            Get
                If CurrDeployment IsNot Nothing Then
                    Return CurrDeployment.TimeOfLastUpdateCheck
                End If
                Return Nothing
            End Get
        End Property
    
        Public Sub CheckAsync(ByVal checkType As UpdateType)
            Try
                Dim show As Boolean = (checkType = UpdateType.Manual)
                If ApplicationDeployment.IsNetworkDeployed AndAlso _
                   Not WindowActive(show) AndAlso Not _checking AndAlso _
                   (checkType = UpdateType.Manual OrElse Not LastUpdateCheck.HasValue OrElse LastUpdateCheck.Value.AddMinutes(60) <= Date.UtcNow) Then
    
                    _checking = True
    
                    CurrDeployment = ApplicationDeployment.CurrentDeployment
                    CurrType = checkType
    
                    Dim bw As New BackgroundWorker
                    AddHandler bw.RunWorkerCompleted, AddressOf CurrDeployment_CheckForUpdateCompleted
                    AddHandler bw.DoWork, AddressOf StartAsync
    
                    If CurrType = UpdateType.Manual Then ShowWindow()
    
                    bw.RunWorkerAsync()
                ElseIf checkType = UpdateType.Manual AndAlso _checking Then
                    CurrType = checkType
                    WindowActive(True)
                ElseIf checkType = UpdateType.Manual AndAlso Not ApplicationDeployment.IsNetworkDeployed Then
                    MessageBox.Show(MainForm, "Cannot check for updates.", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Catch ex As Exception
                If Not _lastErrorSentOnCheck.HasValue OrElse _lastErrorSentOnCheck.Value.AddHours(1) <= Now Then
                    _lastErrorSentOnCheck = Now
                    My.Application.LogError(ex, New StringPair("Update Check", checkType.ToString))
                End If
            End Try
        End Sub
    
        Private Sub StartAsync(ByVal sender As Object, ByVal e As DoWorkEventArgs)
            e.Result = CurrDeployment.CheckForDetailedUpdate
        End Sub
    
        Private Sub ShowWindow()
            My.Forms.frmUpdates.MdiParent = MainForm
            AddHandler My.Forms.frmUpdates.FormClosing, AddressOf frmUpdates_FormClosing
            My.Forms.frmUpdates.Show()
        End Sub
    
        Protected Sub frmUpdates_FormClosing(ByVal sender As Object, ByVal e As Windows.Forms.FormClosingEventArgs)
            My.Forms.frmUpdates = Nothing
        End Sub
    
        Private Function WindowActive(ByVal onTop As Boolean) As Boolean
            If Not My.Forms.frmUpdates Is Nothing Then
                If Not My.Forms.frmUpdates.Visible AndAlso onTop Then
                    My.Forms.frmUpdates.MdiParent = MainForm
                    My.Forms.frmUpdates.Show()
                ElseIf onTop Then
                    My.Forms.frmUpdates.Activate()
                End If
                Return True
            End If
            Return False
        End Function
    
        Private Sub CurrDeployment_CheckForUpdateCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs)
            If MainForm.InvokeRequired Then
                MainForm.Invoke(New RunWorkerCompletedEventHandler(AddressOf CurrDeployment_CheckForUpdateCompleted), sender, e)
            Else
                If e.Error IsNot Nothing Then
                    If WindowActive(True) Then My.Forms.frmUpdates.ShowError("Please try again later.")
    
                    If Not _lastErrorSentOnCheck.HasValue OrElse _lastErrorSentOnCheck.Value.AddHours(1) <= Now Then
                        _lastErrorSentOnCheck = Now
                        My.Application.LogError(e.Error, New StringPair("Update Check Async", CurrType.ToString))
                    End If
                Else
                    Dim updateInfo As UpdateCheckInfo = DirectCast(e.Result, UpdateCheckInfo)
                    Select Case CurrType
                        Case UpdateType.Manual
                            If WindowActive(False) Then My.Forms.frmUpdates.ShowCheckComplete(updateInfo)
                        Case UpdateType.Automatic
                            If updateInfo.UpdateAvailable Then
                                If Not WindowActive(True) Then ShowWindow()
                                My.Forms.frmUpdates.ShowCheckComplete(updateInfo)
                            End If
                    End Select
                End If
                _checking = False
                End If
    
            DirectCast(sender, BackgroundWorker).Dispose()
        End Sub
    
        Public Sub UpdateAsync()
            If ApplicationDeployment.IsNetworkDeployed Then
                CurrDeployment = ApplicationDeployment.CurrentDeployment
    
                Dim bw As New BackgroundWorker
                AddHandler bw.RunWorkerCompleted, AddressOf CurrDeployment_UpdateCompleted
                AddHandler bw.DoWork, AddressOf StartUpdateAsync
    
                My.Forms.frmUpdates.ShowUpdateStart()
    
                bw.RunWorkerAsync()
            End If
        End Sub
    
        Public Sub StartUpdateAsync()
            CurrDeployment.Update()
        End Sub
    
        Private Sub CurrDeployment_UpdateCompleted(ByVal sender As Object, ByVal e As RunWorkerCompletedEventArgs) Handles CurrDeployment.UpdateCompleted
            If MainForm.InvokeRequired Then
                MainForm.Invoke(New AsyncCompletedEventHandler(AddressOf CurrDeployment_UpdateCompleted), sender, e)
            Else
                If e.Error IsNot Nothing Then
                    If WindowActive(True) Then My.Forms.frmUpdates.ShowError("Please try again later or close and re-open the application to automatically retrieve updates.")
                    My.Application.LogError(e.Error, New StringPair("Update Async", CurrType.ToString))
                Else
                    If WindowActive(True) Then My.Forms.frmUpdates.ShowUpdateComplete()
                End If
            End If
        End Sub
    End Class
