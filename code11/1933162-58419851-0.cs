    public int addRecord(BookInformation bookInfo, List<BookInformation> bookList)
    		{
    			try
    			{
    				using (SqlConnection conn = new SqlConnection("Your Connection String Here"))
    				{
    					conn.Open();
    					using (SqlCommand cmd = new SqlCommand("SP_InsertBookHeader", conn))
    					{
    						cmd.CommandType = CommandType.StoredProcedure;
    						cmd.Parameters.Add("@BookID", SqlDbType.VarChar).Value = bookInfo.BookID;
    						cmd.Parameters.Add("@Copies", SqlDbType.Int).Value = bookInfo.Copies;
    						cmd.Parameters.Add("@Date", SqlDbType.DateTime).Value = bookInfo.Date;
    						cmd.ExecuteNonQuery();
    					}
    
    					using (SqlCommand cmdLine = new SqlCommand("SP_InsertBookDetail", conn))
    					{
    						cmdLine.CommandType = CommandType.StoredProcedure;
    						foreach (BookInformation items in bookList)
    						{
    							cmdLine.Parameters.Clear();
    							cmdLine.Parameters.Add("@BookID", SqlDbType.VarChar, 20).Value = items.BookID;
    							cmdLine.Parameters.Add("@ISBN", SqlDbType.VarChar, 50).Value = items.ISBN;
    							cmdLine.Parameters.Add("@Name", SqlDbType.VarChar, 100).Value = items.Name;
    							cmdLine.Parameters.Add("@Description", SqlDbType.VarChar, 10).Value = items.Description;
    							cmdLine.Parameters.Add("@PublishDate", SqlDbType.DateTime).Value = items.PublishDate;
    							cmdLine.Parameters.Add("@Language", SqlDbType.VarChar, 20).Value = items.Language;
    							cmdLine.Parameters.Add("@AuthorID", SqlDbType.VarChar, 20).Value = items.AuthorID;
    							cmdLine.Parameters.Add("@Category", SqlDbType.VarChar, 20).Value = items.Category;
    							cmdLine.Parameters.Add("@Edition", SqlDbType.Int).Value = items.Edition;
    							cmdLine.Parameters.Add("@Price", SqlDbType.Decimal, 18).Value = items.Price;
    							cmdLine.ExecuteNonQuery();
    						}
    					}
    					return bookList.Count; //not really sure what you want to return here
    				}
    			}
    			catch (Exception ex)
    			{
    				//Do something with your exceptions here.
    				//Log them in the database or an exception log
    				//report this back to the calling application or the user
    			}
    		}
