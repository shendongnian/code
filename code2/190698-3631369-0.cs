    Public Sub setbigbold(ByVal c As Control)
        Using nf As New System.Drawing.Font("Arial", 12.0F, _
            System.Drawing.FontStyle.Bold)
    
            c.Font = nf
            c.Text = "This is 12-point Arial bold"
        End Using
    End Sub
