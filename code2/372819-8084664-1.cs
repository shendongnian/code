    public partial class Feature : Page
    {
        // ...
    	protected void Page_Load( object sender, EventArgs e )
    	{
            Master.ThePropertyOfTheContainedControl = "Some nice text.";
    	}
        // ...
     }
