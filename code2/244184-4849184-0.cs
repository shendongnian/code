    Dim r As TableRow
        Dim c As TableCell
        Dim lit As Literal
    
        Me.displayTable.Rows.Clear()
    
        r = AddRow(Me.displayTable, 0)
        c = AddCell(r, 100)
    
        lit = New Literal
        lit.Text = "Thank you for registering your interest."
        c.Controls.Add(lit)
