    /*
     * User: TMPCSigit aswzen@gmail.com
     * Date: 25/11/2019
     * Time: 11:28
     * 
     */
    using System;
    using System.IO;
    using System.Text.RegularExpressions;
    using System.Windows.Forms;
    
    using NPOI.HSSF.UserModel;
    using NPOI.SS.UserModel;
    using NPOI.XSSF.UserModel;
    
    namespace Employee_Manager
    {
    	public static class ExportHelper
    	{		
            public static void WriteCell( ISheet sheet, int columnIndex, int rowIndex, string value )
            {
                var row = sheet.GetRow( rowIndex ) ?? sheet.CreateRow( rowIndex );
                var cell = row.GetCell( columnIndex ) ?? row.CreateCell( columnIndex );
    
                cell.SetCellValue( value );
            }
            public static void WriteCell( ISheet sheet, int columnIndex, int rowIndex, double value )
            {
                var row = sheet.GetRow( rowIndex ) ?? sheet.CreateRow( rowIndex );
                var cell = row.GetCell( columnIndex ) ?? row.CreateCell( columnIndex );
    
                cell.SetCellValue( value );
            }
            public static void WriteCell( ISheet sheet, int columnIndex, int rowIndex, DateTime value )
            {
                var row = sheet.GetRow( rowIndex ) ?? sheet.CreateRow( rowIndex );
                var cell = row.GetCell( columnIndex ) ?? row.CreateCell( columnIndex );
    
                cell.SetCellValue( value );
            }
            public static void WriteStyle( ISheet sheet, int columnIndex, int rowIndex, ICellStyle style )
            {
                var row = sheet.GetRow( rowIndex ) ?? sheet.CreateRow( rowIndex );
                var cell = row.GetCell( columnIndex ) ?? row.CreateCell( columnIndex );
    
                cell.CellStyle = style;
            }
            
            public static IWorkbook CreateNewBook( string filePath )
            {
                IWorkbook book;
                var extension = Path.GetExtension( filePath );
    
                // HSSF => Microsoft Excel(xls形式)(excel 97-2003)
                // XSSF => Office Open XML Workbook形式(xlsx形式)(excel 2007以降)
                if( extension == ".xls" ) {
                    book = new HSSFWorkbook();
                }
                else if( extension == ".xlsx" ) {
                    book = new XSSFWorkbook();
                }
                else {
                    throw new ApplicationException( "CreateNewBook: invalid extension" );
                }
    
                return book;
            }
    		public static void createXls(DataGridView dg){
    			try {
            		string filePath = "";
        		 	SaveFileDialog sfd = new SaveFileDialog();
    		        sfd.Filter = "Excel XLS (*.xls)|*.xls";
    		        sfd.FileName = "Export.xls";
    		        if (sfd.ShowDialog() == DialogResult.OK)
    		        {
    		        	filePath = sfd.FileName;
    	                var book = CreateNewBook( filePath );
    	                book.CreateSheet( "Employee" );
    	                var sheet = book.GetSheet( "Employee" );
    	                int columnCount = dg.ColumnCount;
    		            string columnNames = "";
    		            string[] output = new string[dg.RowCount + 1];
    		            for (int i = 0; i < columnCount; i++)
    		            {
    		            	WriteCell( sheet, i, 0, SplitCamelCase(dg.Columns[i].Name.ToString()) );
    		            }
    		            for (int i = 0; i < dg.RowCount; i++)
    		            {
    		                for (int j = 0; j < columnCount; j++)
    		                {
    		            		var celData =  dg.Rows[i].Cells[j].Value;
    		            		if(celData == "" || celData == null){
    		            			celData = "-";
    		            		}
    		            		if(celData.ToString() == "System.Drawing.Bitmap"){
    		            			celData = "Ada";
    		            		}
    		            		WriteCell( sheet, j, i+1, celData.ToString() );
    		                }
    		            }
    	                var style = book.CreateCellStyle();
    	                style.DataFormat = book.CreateDataFormat().GetFormat( "yyyy/mm/dd" );
    	                WriteStyle( sheet, 0, 4, style );
    	                using( var fs = new FileStream( filePath, FileMode.Create ) ) {
    	                    book.Write( fs );
    	                }
    		        }
                }
                catch( Exception ex ) {
                    Console.WriteLine( ex );
                }
    		}
    	  	public static string SplitCamelCase(string input)
    		{
    		    return Regex.Replace(input, "(?<=[a-z])([A-Z])", " $1", RegexOptions.Compiled);
    		}
    	}
    }
