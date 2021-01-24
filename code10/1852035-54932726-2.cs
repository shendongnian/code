    private void SendExcelToDatabase(string Filename)
    {
        int rowThread = HowManyRowsYouWouldLikeToSkipInExcel;
        var data = ExcelFileRead(Filename);
        using (var db = new ProviderBreakfastDBEntities())
        {
            foreach (DataRow record in data.Tables[0].Rows)
            {  
                if (!(rowThreshold >= x))
                {
                int rank;
                var isValidRank = int.TryParse(record["Ranking"].ToString(), out rank);
                db.ProviderBreakfastExcels.Add(new ProviderBreakfastExcel
                {   
                    Ranking = isValidRank ? rank : new int?(), 
                    Contact = record["Contact"].ToString(),
                    LastName = record["LastName"].ToString(),
                    FirstName = record["FirstName"].ToString(),
                    // Bedsize = isValidBedsize ? beds : new int?(),
                    Bedsize = Convert.ToInt32(record["Bedsize"].ToString()),
                    City = record["City"].ToString(),
                    Company = record["Company"].ToString(),
                    JobTitle = record["JobTitle"].ToString(),
                    State = record["State"].ToString()
                }); 
            }
          }
            db.SaveChanges();
    x++
            }
        }
