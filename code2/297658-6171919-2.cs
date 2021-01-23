    protected void Page_Load(object sender, EventItems e)
    {
        if ( !IsPostBack )
        {
            List<string> disciplines = 
            rptDiscipline.DataSource = disciplines;
            rptDiscipline.DataBind();
        }
    }
    protected void rptDiscipline_ItemDataBound(Object Sender, RepeaterItemEventArgs e) 
    {
        // To get your data item, cast e.Item.DataItem to 
        // whatever you're using for the data object
        string discipline = (string) e.Item.DataItem;
        // Get the inner repeater:
        Repeater rptPrograms = (Repeater) e.Item.FindControl("rptPrograms");
        // Create a filtered view of the data that shows only 
        // the disciplines needed for this row
        // table is the datatable that was originally bound to the outer repeater
        DataView dv = new DataView( table );  
        dv.RowFilter = String.Format("Discipline = '{0}'", discipline);
 
        // Set the inner repeater's datasource to whatever it needs to be.
        rptPrograms.DataSource = dv;
        rptPrograms.DataBind();
    }   
