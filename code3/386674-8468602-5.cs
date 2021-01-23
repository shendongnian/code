     <form id="form1" runat="server">
          <h3>PlaceHolder Example</h3>
          <asp:PlaceHolder id="PlaceHolder1" 
               runat="server"/>
       </form>
      protected void Page_Load(Object sender, EventArgs e)
      {
         Graph MyChart = new Graph();
         MyChart.ID = "MyChart";
         PlaceHolder1.Controls.Add(MyChart);
        //genericcontrol example
        HtmlGenericControl NewControl = new HtmlGenericControl("graph");
        // Set the properties of the new HtmlGenericControl control.
        NewControl.ID = "MyGraph";
        PlaceHolder1.Controls.Add(NewControl);
       
      }
