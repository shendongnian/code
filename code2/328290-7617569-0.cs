    public void TrySomethingAwesome(){
        try
        {
            //try to do something awesome
        }
        catch (Exception ex)
        {   
		    ScriptManager.RegisterStartupScript(Page, typeof(Page), "showError",
                string.Format("ShowError({0});", "Oops! Something went wrong :("), true);
        }
	}
