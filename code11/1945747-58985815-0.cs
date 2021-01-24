    Public Function Convert(value As Object, targetType As Type, parameter As Object, culture As CultureInfo) As Object Implements IValueConverter.Convert
            Dim doubleValue As [Double] = 0.0
            If value IsNot Nothing Then
    
                Dim Input As String = TryCast(value, String)
                If Not String.IsNullOrEmpty(Input) Or
                        Not String.IsNullOrWhiteSpace(Input) Then
                    Input = Input.Replace("$", "")
                    Input = Input.Replace(" ", "")
                    Input = Input.Replace(",", "")
                    Input = Input.Replace(")", "")
                    Input = Input.Replace("(", "-")                
    
                    If [Double].TryParse(Input.ToString(), doubleValue) Then
    
                        If doubleValue < 0 Then
                            Return -1
                        End If
                    End If
                End If
    
            End If
            Return 1
        End Function
