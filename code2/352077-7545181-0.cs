    Imports System.Runtime.InteropServices
    
    Friend Class StopWatch
    
        Private Elapsed As Integer
        Private StartTimeStamp As Integer
    
        Public Sub Start()
            If Not Me._IsRunning Then
                Me.StartTimeStamp = StopWatch.timeGetTime
                Me._IsRunning = True
            End If
        End Sub
    
        Public Sub [Stop]()
            If Me.isRunning Then
                Me.Elapsed = (Me.Elapsed + (StopWatch.timeGetTime - Me.StartTimeStamp))
                Me._IsRunning = False
                If (Me.Elapsed < 0) Then
                    Me.Elapsed = 0
                End If
            End If
        End Sub
    
        Public Sub Reset()
            Me.Elapsed = 0
            Me._IsRunning = False
            Me.StartTimeStamp = 0
        End Sub
    
        Private _IsRunning As Boolean
        Public ReadOnly Property IsRunning() As Boolean
            Get
                Return Me._IsRunning
            End Get
        End Property
    
        Public ReadOnly Property ElapsedMilliseconds() As Integer
            Get
                Dim elapsed = Me.Elapsed
                If Me._IsRunning Then
                    elapsed = (elapsed + (StopWatch.timeGetTime - Me.StartTimeStamp))
                End If
                Return elapsed
            End Get
        End Property
    
        <DllImport("winmm.dll", SetLastError:=True)> _
        Private Shared Function timeGetTime() As Integer
        End Function
    
    End Class
