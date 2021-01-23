	using System;
	using System.Data;
	using System.Data.OleDb;
	using System.Collections.Generic;
	using System.Text; 
	 
	namespace Excelcalling1
	{
	    class Program
	    {
	        static void Main(string[] args)
	        {
                string F1Name = "C:\\Documents and Settings\\origin\\Desktop\\New Folder\\Book1.xls";
				string CnStr = ("Provider=Microsoft.Jet.OLEDB.4.0;" + ("Data Source="	 
				+ ( F1Name + (";" + "Extended Properties=\"Excel 8.0;\""))));
				DataSet ds = new DataSet();
				OleDbDataAdapter DA = new OleDbDataAdapter("Select * from [Sheet1$]", CnStr);                         
				Console.WriteLine("File Accessed!!!!");                                                 
	 
				try
				{ 
					DA.Fill(ds, "srlno");
					foreach (DataRow dr in ds.Tables["srlno"].Rows)
					{                        
						Console.WriteLine(dr["A"] + "\t" + dr["B"] + "\t" + dr["C"]);
					}
				}
	            catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
				}
				Console.ReadLine();
	        }  
	    }
	}
