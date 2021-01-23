    Imports System.Threading
    Imports System.Threading.Tasks
    
    Public Class wbBrowser
        Implements IDisposable
    
        Dim m_wbBrowser As New WebBrowser
        Dim m_tcs As TaskCompletionSource(Of WebBrowser)
    
        Public Sub New()
            m_wbBrowser.ScrollBarsEnabled = False
            m_wbBrowser.ScriptErrorsSuppressed = False
            AddHandler m_wbBrowser.DocumentCompleted, Sub(s, args) m_tcs.SetResult(m_wbBrowser)
        End Sub
    
        Public Async Function GetBrowserAsync(ByVal URL As String) As Task(Of WebBrowser)
            m_wbBrowser.Navigate(URL)
            Return Await WhenDocumentCompleted(m_wbBrowser)
        End Function
    
        Private Function WhenDocumentCompleted(browser As WebBrowser) As Task(Of WebBrowser)
            m_tcs = New TaskCompletionSource(Of WebBrowser)
            Return m_tcs.Task
        End Function
    
        Private disposedValue As Boolean
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    m_wbBrowser.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    
    End Class
