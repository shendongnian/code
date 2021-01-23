     Public Sub LayoutControl(ByVal c As Control, ByVal column As Integer, ByVal row As Integer)
            If TypeOf c Is Label Then
                Dim clabel As Label = DirectCast(c, Label)
                clabel.TextAlign = ContentAlignment.TopCenter
                clabel.Dock = DockStyle.Right
                clabel.Margin = New Padding(clabel.Margin.Left, clabel.Margin.Top + 5, clabel.Margin.Right, clabel.Margin.Bottom)
    
            ElseIf TypeOf c Is System.Windows.Forms.TextBox Then
                Dim ctbox As System.Windows.Forms.TextBox = DirectCast(c, System.Windows.Forms.TextBox)
                ctbox.Margin = New Padding(0, 3, 0, 3)
                ctbox.TextAlign = HorizontalAlignment.Center
            End If
    
            TableLayoutPanel1.Controls.Add(c, column, row)
        End Sub
    
      Public Sub SetupTableLayout(ByVal numOfColumns As Integer, ByVal numOfRows As Integer)
            TableLayoutPanel1.ColumnCount = numOfColumns
            TableLayoutPanel1.RowCount = numOfRows
            While TableLayoutPanel1.RowStyles.Count < TableLayoutPanel1.RowCount
                TableLayoutPanel1.RowStyles.Add(New RowStyle())
            End While
    
            For Each row As RowStyle In TableLayoutPanel1.RowStyles
                With row
                    .SizeType = SizeType.Percent
                    .Height = 100 / TableLayoutPanel1.RowCount
                End With
            Next row
        End Sub
