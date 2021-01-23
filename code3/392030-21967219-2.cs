    Imports System.Threading
    Imports System.Threading.Tasks
    
    Public Class wbBrowser
        Implements IDisposable
        Dim ieBrowser As New WebBrowser
    
        Public Async Function GetBrowserAsync(ByVal URL As String) As Task(Of WebBrowser)
            ieBrowser.ScrollBarsEnabled = False
            ieBrowser.ScriptErrorsSuppressed = False
            ieBrowser.Navigate(URL)
            Return Await WhenDocumentCompleted(ieBrowser)
        End Function
    
        Private Function WhenDocumentCompleted(browser As WebBrowser) As Task(Of WebBrowser)
            Dim tcs = New TaskCompletionSource(Of WebBrowser)
            AddHandler browser.DocumentCompleted, Sub(s, args) tcs.SetResult(browser)
            Return tcs.Task
        End Function
    
        Private disposedValue As Boolean
        Protected Overridable Sub Dispose(disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    ieBrowser.Dispose()
                End If
            End If
            Me.disposedValue = True
        End Sub
        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(Me)
        End Sub
    
    End Class
