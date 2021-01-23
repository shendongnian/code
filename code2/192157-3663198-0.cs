    Public Shared Function CustomFormatCurrency(ByVal input As Decimal) As String 
        Dim nfi As System.Globalization.NumberFormatInfo = New System.Globalization.NumberFormatInfo  
        nfi.CurrencyDecimalDigits = 0  
        nfi.CurrencySymbol = "$" 
        Return String.Format(nfi, "{0:C}", input)  
    End Function 
