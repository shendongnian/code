    public class PersoCont2 : Panel
    {
    	Label lblUp = null;
    
    	bool isBorder;
    	Color borderColor;
    
    	public bool is_border
    	{
    		get { return isBorder; }
    		set { isBorder = value; Rearrange( ); }
    	}
    
    	public Color border_color
    	{
    		get { return borderColor; }
    		set { borderColor = value; Rearrange( ); }
    	}
    
        protected override void OnHandleCreated(EventArgs e)
            {
                Rearrange();
            }
    
    	private void Rearrange( )
    	{
    		if( lblUp != null )
    		{
    			Controls.Remove( lblUp );
    			lblUp = null;
    		}
    		if( is_border )
    		{
    			lblUp = new Label( );
    			lblUp.BackColor = borderColor;
    			// TODO: set properties
    			// . . .
    			lblUp.Location = new Point( 10, 10 );
    			Controls.Add( lblUp );
    		}
    	}
    }
