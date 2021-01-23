	protected void Page_Load( object sender, EventArgs e )
	{
		if( !Page.IsPostBack )
		{
			SV.Instance.Revenue.Set( 1234567890M );
			SV.Instance.FiscalDate.Set( new DateTime( 2011, 3, 15 ) );
		}
	}
	protected void Button1_Click( object sender, EventArgs e )
	{
		DateTime when = SV.Instance.FiscalDate.Get( );
		decimal amount = SV.Instance.Revenue.Get( );
	}
