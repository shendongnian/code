    Public Shared Event CallEvent As ValueEnterEventHandler
    Public Shared Sub DispatchCompanyCall(moduleName As String)
        If IsReady AndAlso CallEvent IsNot Nothing Then
            RaiseEvent CallEvent(Nothing, New ValueEnterEventArgs(moduleName, False))
        End If
    End Sub
