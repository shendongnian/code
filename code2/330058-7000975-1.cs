    <ValueConversion(GetType(Boolean), GetType(Visibility))> _
    Public Class BoolToVisibilityConverter
        Implements IValueConverter
    
        Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.Convert
    
            If value IsNot Nothing Then
                If value = True Then 
                    Return Visibility.Visible
                Else
                    Return Visibility.Collapsed
                End If
            Else
                Return Visibility.Collapsed
            End If
        End Function
    
        Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements System.Windows.Data.IValueConverter.ConvertBack
            Throw New NotImplementedException
        End Function
    End Class
