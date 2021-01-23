    public static void updateInfo(string ID, string email, bool pub)
    {
        try
        {
            using (MyDataDataContext db = GetNewDataContext()) 
            {
                User user = db.Users.SingleOrDefault(x => x.UserId == long.Parse(ID));
                if (user != null)
                {
                    user.Email = email;
                    user.Publish = publish;
                }
                db.SubmitChanges();
            }
        }
        catch (Exception ex)
        {
            //Log error
            Log(ex.ToString());
            // TODO: Consider adding throw or telling the user of the error.
            // throw;
        }
    }
