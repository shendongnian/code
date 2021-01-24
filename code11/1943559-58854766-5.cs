        public bool IncrementCountForURL(int idUrl)
        {
            bool flg=false;
            try
            { 
                //This is my DB class to manage my context. You would need to handle it according to your DB context
                using (DBManager db = new DBManager())
                {
                        string Query = "UPDATE {yourTable} SET urlcount=urlcount+1 WHERE idUrl=@idUrl";
                        db.Open();
                        db.CreateParameters(1);
                        db.AddParameters(0, "@idUrl", idUrl);
                        int i = db.ExecuteNonQuery (CommandType.Text, Query);
                        if (i > 0)
                        {
                            flg = true;
                        }
                        else
                        {
                           flg=false;
                        }
                }
            }
            catch (Exception ex)
            {
             //Handle your exception
             flg=false;
            }
            return flg;
        }
