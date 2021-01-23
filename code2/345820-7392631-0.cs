    protected void Button1_Click(object sender, EventArgs e)
    {
        int userID = 250;
        SBMData2.SBMDataContext db = new SBMData2.SBMDataContext();
    
        var addresses = db.Addresses.Where(x => x.UserID == userId);
    
        foreach (var address in addresses)
        {
            try
            {
                db.Addresses.DeleteOnSubmit(address);
                db.SubmitChanges();
            }
            catch (Exception ex)
            {
                Label1.Text += ex.StackTrace.ToString();
            }
        }
    }
