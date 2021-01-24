    class Program
    {
    	static void Main(string[] args)
    	{
    		try
    		{
    			using (SPSite site = new SPSite("http://somesite.local/sites/promo_tool"))
    			{
    				using (SPWeb myWeb = site.OpenWeb())
    				{
    					SPList target = myWeb.Lists["Headers List"];
    					SPListItemCollection items = target.GetItems();
    					DataTable dt = items.GetDataTable();
    
    					if (dt.Rows.Count > 0)
    					{
    						string consString = "SQL Connection String";
    						using (SqlConnection con = new SqlConnection(consString))
    						{
    							using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
    							{
    								sqlBulkCopy.DestinationTableName = "Table1";
    								sqlBulkCopy.ColumnMappings.Add("ID", "ID");
    								sqlBulkCopy.ColumnMappings.Add("_x0160_ifra_x0020_artikla", "_x0160_ifra_x0020_artikla");
    								sqlBulkCopy.ColumnMappings.Add("Naziv_x0020_artikla", "Naziv_x0020_artikla");
    								sqlBulkCopy.ColumnMappings.Add("Katalog_x002f_ID", "Katalog_x002f_ID");
    								sqlBulkCopy.ColumnMappings.Add("Status_x0020_kataloga", "Status_x0020_kataloga");
    								sqlBulkCopy.ColumnMappings.Add("Datum_x0020_po_x010d_etka_x0020_", "Datum_x0020_po_x010d_etka_x0020_");
    								con.Open();
    								sqlBulkCopy.WriteToServer(dt);
    								con.Close();
    							}
    						}
    					}
    				}
    			}
    		}
    		catch (Exception ex)
    		{
    			Console.WriteLine(ex.Message);
    			Console.ReadKey();
    		}
    	}
    }
