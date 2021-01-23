    Public Sub New()
        InitializeComponent()
        Dim col = DataGridView1.Columns.Add("sales", "Sales")
        DataGridView1.Columns(col).ValueType = GetType(Decimal)
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.AllowUserToDeleteRows = False
        DataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders
        With System.Globalization.CultureInfo.CurrentUICulture
            DataGridView1.Rows.Add(.Calendar.GetMonthsInYear(DateTime.Now.Year))
            For Each row As DataGridViewRow In DataGridView1.Rows
                row.HeaderCell.Value = .DateTimeFormat.MonthNames(row.Index)
                row.Cells(col).Value = 0
            Next
        End With
    End Sub
