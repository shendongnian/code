    Public Shared ValueProperty As DependencyProperty = DependencyProperty.Register("Value", GetType(String), GetType(XDateTimePicker), New PropertyMetadata(Nothing, AddressOf ValuePropertyChangedCallback))
    Public Shared Sub ValuePropertyChangedCallback(ByVal dependencyObject As DependencyObject, ByVal dependencyPropertyChangedEventArgs As DependencyPropertyChangedEventArgs)
        DirectCast(dependencyObject, MyUserControl).NotifyErrorsChanged("Value")
    End Sub
    Private Sub MyUserControl_BindingValidationError(ByVal sender As Object, ByVal e As System.Windows.Controls.ValidationErrorEventArgs) Handles Me.BindingValidationError
        Me.NotifyErrorsChanged("Value")
    End Sub
    Public Sub NotifyErrorsChanged(ByVal propertyName As String)
        RaiseEvent ErrorsChanged(Me, New System.ComponentModel.DataErrorsChangedEventArgs(propertyName))
    End Sub
