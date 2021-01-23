    Imports System
    Imports System.Web
    Imports System.Threading.Tasks
    Imports System.Threading
    
    Public Class Directory4
        Inherits System.Web.UI.Page
    
        Private Shared cts As CancellationTokenSource = Nothing
        Private Shared LockObj As New Object
        Private Shared SillyValue As Integer = 0
        Private Shared bInterrupted As Boolean = False
        Private Shared bAllDone As Boolean = False
    
        Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    
        End Sub
    
    
        Protected Sub DoStatusMessage(ByVal Msg As String)
    
            Me.lblMessages.Text = Msg
            Debug.Print(Msg)
        End Sub
    
        Protected Sub btn_Start_Click(sender As Object, e As EventArgs) Handles btn_Start.Click
    
            If Not IsNothing(CTS) Then
                If Not cts.IsCancellationRequested Then
                    DoStatusMessage("Please cancel the running process first.")
                    Exit Sub
                End If
                cts.Dispose()
                cts = Nothing
                DoStatusMessage("Plase cancel the running process or wait for it to complete.")
            End If
            bInterrupted = False
            bAllDone = False
            Dim ncts As New CancellationTokenSource
            cts = ncts
    
            ' Pass the token to the cancelable operation.
            ThreadPool.QueueUserWorkItem(New WaitCallback(AddressOf DoSomeWork), cts.Token)
            DoStatusMessage("This Task has now started.")
    
            Timer1.Interval = 1000
            Timer1.Enabled = True
        End Sub
    
        Protected Sub StopThread()
            If IsNothing(cts) Then Exit Sub
            SyncLock (LockObj)
                cts.Cancel()
                System.Threading.Thread.SpinWait(1)
                cts.Dispose()
                cts = Nothing
                bAllDone = True
            End SyncLock
    
    
        End Sub
    
        Protected Sub btn_Stop_Click(sender As Object, e As EventArgs) Handles btn_Stop.Click
            If bAllDone Then
                DoStatusMessage("Nothing running. Start the task if you like.")
                Exit Sub
            End If
            bInterrupted = True
            btn_Start.Enabled = True
    
            StopThread()
    
            DoStatusMessage("This Canceled Task has now been gently terminated.")
        End Sub
    
    
        Sub Refresh_Parent_Webpage_and_Exit()
            '***** This refreshes the parent page.
            Dim csname1 As [String] = "Exit_from_Dir4"
            Dim cstype As Type = [GetType]()
    
            ' Get a ClientScriptManager reference from the Page class.
            Dim cs As ClientScriptManager = Page.ClientScript
    
            ' Check to see if the startup script is already registered.
            If Not cs.IsStartupScriptRegistered(cstype, csname1) Then
                Dim cstext1 As New StringBuilder()
                cstext1.Append("<script language=javascript>window.close();</script>")
                cs.RegisterStartupScript(cstype, csname1, cstext1.ToString())
            End If
        End Sub
    
    
        'Thread 2: The worker
        Shared Sub DoSomeWork(ByVal token As CancellationToken)
            Dim i As Integer
    
            If IsNothing(token) Then
                Debug.Print("Empty cancellation token passed.")
                Exit Sub
            End If
    
            SyncLock (LockObj)
                SillyValue = 0
    
            End SyncLock
    
    
            'Dim token As CancellationToken = CType(obj, CancellationToken)
            For i = 0 To 10
    
                ' Simulating work.
                System.Threading.Thread.Yield()
    
                Thread.Sleep(1000)
                SyncLock (LockObj)
                    SillyValue += 1
                End SyncLock
                If token.IsCancellationRequested Then
                    SyncLock (LockObj)
                        bAllDone = True
                    End SyncLock
                    Exit For
                End If
            Next
            SyncLock (LockObj)
                bAllDone = True
            End SyncLock
        End Sub
    
        Protected Sub Timer1_Tick(sender As Object, e As System.EventArgs) Handles Timer1.Tick
            '    '***** This is for ending the task normally.
    
    
            If bAllDone Then
                If bInterrupted Then
                    DoStatusMessage("Processing terminated by user")
                Else
    
                    DoStatusMessage("This Task has has completed normally.")
                End If
    
                'Timer1.Change(System.Threading.Timeout.Infinite, 0)
                Timer1.Enabled = False
                StopThread()
    
                Exit Sub
            End If
            DoStatusMessage("Working:" & CStr(SillyValue))
    
        End Sub
    End Class
    
