    using (TestDBEntities ctx = new TestDBEntities())
    {
    	var allStore = ctx.Stores;
    	foreach(var store in allStore)
    	{
    		store.LogoAlign = (String.Compare(drpLogoAlign.SelectedValue, String.Empty) == 0 ? "NULL" : "'" + drpLogoAlign.SelectedValue + "'");
    		store.Height = txtHeight.Text.ToString();
    	}
    	ctx.SaveChanges();
    }
