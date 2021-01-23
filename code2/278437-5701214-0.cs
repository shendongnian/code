       With DgCardVoc
                                '.DataSource = ldstList.Tables(0)
    
                                .ColumnHeadersDefaultCellStyle.Font = New Font("Verdana", 12.0F, FontStyle.Bold, GraphicsUnit.Pixel)
                                .ColumnHeadersDefaultCellStyle.BackColor = Color.GreenYellow
                                .EnableHeadersVisualStyles = False
                                If .Columns.Count < 3 Then
                                    .Columns.Add("ID", "Id")
                                    .Columns.Add("c1", "c1")
                                    .Columns.Add("c2", "c2")
                                End If
                                count = ldstList.Tables(0).Rows.Count
                                .Rows.Clear()
                                For i = 0 To count - 1
                                    Dim row() As String = {True, ldstList.Tables(0).Rows(i)(0), ldstList.Tables(0).Rows(i)(1), Format(ldstList.Tables(0).Rows(i)(2), "dd-MM-yyyy hh:mm ttttt")}
                                    .Rows.Add(row)
                                Next i
                                .Columns(1).Visible = False
                                For i = 1 To .ColumnCount - 1
                                    .Columns(i).ReadOnly = True
                                Next i
                                .Columns(0).Width = "72"
                                .Columns(2).Width = "300"
                                .Columns(3).Width = "185"
    
                                .RowsDefaultCellStyle.BackColor = Color.Beige
                                .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(224, 255, 179)
                                .DefaultCellStyle.Font = New Font("Verdana", 12.0F, FontStyle.Regular, GraphicsUnit.Pixel)
                                .DefaultCellStyle.ForeColor = Color.Black
                                .Refresh()
                            End With
