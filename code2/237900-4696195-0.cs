        Dim tbl As New DataTable
        tbl.Columns.Add("ID", GetType(Int32))
        tbl.Columns.Add("Name", GetType(String))
        tbl.Columns.Add("Birthday", GetType(Date))
        Dim pers As DataRow = tbl.NewRow
        pers("ID") = 1
        pers("Name") = "Tim"
        pers("Birthday") = New Date(1973, 6, 9)
        'use AutoGenerateColumnsto let grid generate the column itself'
        Me.GridView1.AutoGenerateColumns = True
        Me.GridView1.DataSource = tbl
        Me.GridView1.DataBind()
    
        'or dynamically generate the columns'
        For Each col As DataColumn In tbl.Columns
            Dim field As New BoundField
            field.DataField = col.ColumnName
            field.HeaderText = col.ColumnName
            GridView1.Columns.Add(field)
        Next
