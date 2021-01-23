    Graph MyChart = new Graph();
    MyChart.ID = "MyChart";
    Page.Controls.Add(MyChart);
    //genericcontrol example
    HtmlGenericControl NewControl = new HtmlGenericControl("graph");
    // Set the properties of the new HtmlGenericControl control.
    NewControl.ID = "MyGraph";
    Page.Controls.Add(NewControl);
 
