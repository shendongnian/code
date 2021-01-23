    protected virtual void Page_Load(object sender, EventArgs e) {
        if(!IsPostBack) {
            this.odsFavoriteFilm.DeleteParameters["CustomerId"].DefaultValue = ((MovieMonstrIdentity)Context.User.Identity).Customer.Id.ToString();
        }
    }
