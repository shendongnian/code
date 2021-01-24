    Private Async Function OnRequestBlockResourceEventHandler(ByVal sender As Object, ByVal e As SessionEventArgs) As Task
       ' *** Change to Sub() ***
       Return Await Task.Run(Sub()
    
                                      If e.HttpClient.Request.RequestUri.ToString().Contains("analytics") Then
                                          Dim customBody As String = String.Empty
                                          e.Ok(Encoding.UTF8.GetBytes(customBody))
                                      End If
                                  ' *** Change to End Sub ***
    			                End Sub)
        End Function
