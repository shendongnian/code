     Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim table As New DataTable
            Dim row As DataRow
            table.Columns.Add(New DataColumn("name", System.Type.GetType("System.String")))
            For i As Integer = 1 To 30
                row = table.NewRow
                row("name") = "name" & i
                table.Rows.Add(row)
            Next
            DataGrid1.DataSource = table
            ComboBox1.DataSource = table
            ComboBox1.DisplayMember = "name"
        End Sub
    Private sub DoEvents()
      '// Do anything here
    End Sub
