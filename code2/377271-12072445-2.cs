    protected void GridView1_PreRender(object sender, EventArgs e)
    {
      // You only need the following 2 lines of code if you are not 
      // using an ObjectDataSource of SqlDataSource
      GridView1.DataSource = Sample.GetData();
      GridView1.DataBind();
      if (GridView1.Rows.Count > 0)
      {
        //This replaces <td> with <th> and adds the scope attribute
        GridView1.UseAccessibleHeader = true;
        //This will add the <thead> and <tbody> elements
        GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        //This adds the <tfoot> element. 
        //Remove if you don't have a footer row
        GridView1.FooterRow.TableSection = TableRowSection.TableFooter;
       }
    }
