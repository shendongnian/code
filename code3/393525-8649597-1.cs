    private int _uid;
    
    protected void Page_Load( object sender, EventArgs e )
    {
        if( Request["uid"] != null )
        {
            _uid = Int32.Parse( Request["uid"] );
        }
        else
        {
            throw new InvalidOperationException( "uid parameter is missing." );
        }
    
        DisplayStatus();
    }
    
    private void DisplayStatus()
    {
        UserDAO ud = new UserDAO();
        tblUser u = ud.GetUser( _uid );
        AccountStatus.Text = ( ( (Boolean)u.ActiveOrNot ) ? "Active" : "Inactive" ) + "<br />";
    }
    
    protected void btnActivate_OnClick( object sender, EventArgs e )
    {
        UserDAO udao = new UserDAO();
        int userBeingEdited = -1;
    
        if( _uid > default( int ) )
        {
            userBeingEdited = _uid;
        }
        if( udao.ActivateUser( userBeingEdited ) )
        {
            DisplayError( "This user has been activated.", true );
        }
    
        DisplayStatus();
    }
