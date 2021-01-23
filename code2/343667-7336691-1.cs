	private int CustomerID
	{
		get
		{
			if( Session["CustomerID"] != null )
				return Convert.ToInt32( Session["CustomerID"] );
			else
				return 0;
		}
		set { Session["CustomerID"] = value; }
	}
