    Dim dt As DataTable
    Private Sub MyForm_Load()
        Call LoadDefaults()
    End Sub
    Private Sub LoadDefaults()
        dt.Columns.Add("Line", GetType(Int16))
        dt.Columns.Add("Section", GetType(String))
        dt.Columns.Add("Range", GetType(String))
        dt.Columns.Add("Total", GetType(Single))
    End Sub
    Private Sub processButton_Click(sender As Object, e As EventArgs) Handles BtnExcel.Click
        For Each Item In mySplit
            dt.Rows.Add({Item.Trim(), Item.Split("(cost=", StringSplitOptions.None).First(), Regex.Match(Item, @"cost=(.+?) rows").Groups[1].Value, Regex.Match(Item, @"cost=(.+?)\.\.").Groups[1].Value})
        Next
        Me.DataGridView1.DataSource = dt
        ...
        myChart.DataSource = dt
    End Sub
