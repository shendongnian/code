    Using Xlfile As FileStream = New FileStream(FileName, FileMode.Open, FileAccess.Read)
    	Using XLBook As HSSFWorkbook = New HSSFWorkbook(Xlfile)
    		Using XLSheet As NPOI.SS.UserModel.Sheet = XLBook.GetSheetAt(0)
    
    			Dim CurrentRow As NPOI.HSSF.UserModel.HSSFRow
                            Dim CurrentCell As NPOI.SS.UserModel.Cell
                            Dim RowEnum As IEnumerator = XLSheet.GetRowEnumerator()
                            
    			While RowEnum.MoveNext
                              If (RowEnum.Current IsNot Nothing) Then
                                  CurrentRow = TryCast(RowEnum.Current, NPOI.HSSF.UserModel.HSSFRow)
    					Select Case CurrentCell.CellType
    						Case NPOI.SS.UserModel.CellType.STRING
    							' CurrentCell.StringCellValue
    						Case NPOI.SS.UserModel.CellType.NUMERIC
    							' CurrentCell.NumericCellValue.ToString()
    					End Select
    			End While
    		End Using
    	End Using
    	Xlfile.Close()
    End Using
