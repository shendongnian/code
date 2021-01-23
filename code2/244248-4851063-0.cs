       Public ReadOnly Property LastColumn() As Integer
            Get
                Return ExcelWorksheet.UsedRange.Columns.Count + _
                       ExcelWorksheet.UsedRange.Column - 1
            End Get
        End Property
        Public ReadOnly Property LastRow() As Integer
            Get
                Return ExcelWorksheet.UsedRange.Rows.Count + _
                       ExcelWorksheet.UsedRange.Row - 1
            End Get
        End Property
