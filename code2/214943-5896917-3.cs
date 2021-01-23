        Public Event ErrorsChanged(ByVal sender As Object, ByVal e As System.ComponentModel.DataErrorsChangedEventArgs) Implements System.ComponentModel.INotifyDataErrorInfo.ErrorsChanged
    Public Function GetErrors(ByVal propertyName As String) As System.Collections.IEnumerable Implements System.ComponentModel.INotifyDataErrorInfo.GetErrors
        Dim returnValue As System.Collections.IEnumerable = Nothing
        Dim errorMessage As String = Nothing
        If propertyName = "Value" Then
            If Validation.GetErrors(Me).Count = 0 Then
                errorMessage = ""
            Else
                errorMessage = Validation.GetErrors(Me).First.ErrorContent.ToString
            End If
            If String.IsNullOrEmpty(errorMessage) Then
                returnValue = Nothing
            Else
                returnValue = New List(Of String)() From {errorMessage}
            End If
        End If
        Return returnValue
    End Function
    Public ReadOnly Property HasErrors As Boolean Implements System.ComponentModel.INotifyDataErrorInfo.HasErrors
        Get
            Return Validation.GetErrors(Me).Any()
        End Get
    End Property
