    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim table As New DataTable()
        Using conn As New MySqlConnection("server=localhost;userid=root;password=4444;database=database")
            Using cmd As New MySqlCommand("select * from truck_info", conn)
                conn.Open()
                table.Load(cmd.ExecuteReader)
            End Using
        End Using
        DataGridView1.DataSource = table
    End Sub
