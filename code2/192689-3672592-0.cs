    public static Dictionary<int, string> ListOfLists()
    {
        try
        {
            using (ListDataDataContext db = new ListDataDataContext(GetConnectionString("Master")))
            {
                return db.ListMatchingHeaders
                    .Select(r => new { r.ListRecNum, r.ListName })
                    .ToDictionary(t => t.ListRecNum, t => t.ListName);
            }
        }
        catch (Exception)
        {
            MessageBox.Show("Could not connect to database, please check connection and try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return null;
        }
    }
