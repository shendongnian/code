    Public Class Form1
        Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
            Dim newRow(1) As Object
            newRow(0) = "Foo"
            newRow(1) = "Bar"
            DataGridView1.Rows.Add(newRow)
        End Sub
    End Class
