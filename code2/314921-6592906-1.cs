    Public Class Quarter
    
        Public Shared Function GetQuarters(ByVal dt1 As DateTime, ByVal dt2 As DateTime) As Long
            Dim d1Quarter As Double = GetQuarter(dt1.Month)
            Dim d2Quarter As Double = GetQuarter(dt2.Month)
            Dim d1 As Double = d2Quarter - d1Quarter
            Dim d2 As Double = (4 * (dt2.Year - dt1.Year))
            Return Round(d1 + d2)
        End Function
    
        Private Shared Function GetQuarter(ByVal nMonth As Integer) As Integer
            If nMonth <= 3 Then
                Return 1
            End If
            If nMonth <= 6 Then
                Return 2
            End If
            If nMonth <= 9 Then
                Return 3
            End If
            Return 4
        End Function
    
        Private Shared Function Round(ByVal dVal As Double) As Long
            If dVal >= 0 Then
                Return CLng(Math.Floor(dVal))
            End If
            Return CLng(Math.Ceiling(dVal))
        End Function
    
    End Class
