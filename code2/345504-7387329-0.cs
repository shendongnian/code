    using System.Web.UI.DataVisualization.Charting;
    ...
    // Set the legend cell to an image showing selection cleared
    Chart1.Legends[0].CustomItems[0].Cells[0].Image = "./cleared.png";
    Chart1.Legends[0].CustomItems[0].Cells[0].PostBackValue = "item 1";
    // Add an ImageMapEventHandler to the Chart.Click event
    this.Chart1.Click += new ImageMapEventHandler(this.Chart1_Click);
    ...
    // Change the selection image when the user clicks on the legend cell
    private void Chart1_Click(object sender, System.Web.UI.WebControls.ImageMapEventArgs e)
    {
       if (e.PostBackValue == "item 1")
       {
          LegendCell cell = Chart1.Legends[0].CustomItems[0].Cells[0];
          cell.Image = (cell.Image == "./cleared.png") ? "./selected.png" : "./cleared.png";
       }
