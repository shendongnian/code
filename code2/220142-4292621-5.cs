    protected void odsFavoriteFilm_Deleting(object sender, ObjectDataSourceMethodEventArgs e) {
    	if (Context.User.Identity.IsAuthenticated) {
    		e.Command.Parameters["CustomerId"].Value = ((MovieMonstrIdentity)Context.User.Identity).Customer.Id.ToString();
    	}
    }
