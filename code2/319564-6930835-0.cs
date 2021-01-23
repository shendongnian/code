    yourChart.CustomizeLegend += new EventHandler<CustomizeLegendEventArgs> (CustomizeLegendEventHandler);
    //...
    static void CustomizeLegendEventHandler(object sender, CustomizeLegendEventArgs e)
    {
      int anotherIndex = 3;
      if (sender != null && sender is Chart)
      {
        if (e != null && e.LegendItems != null && e.LegendItems.Count > 0)
        {
          Chart ch = ((Chart)sender);
          if (...) //your logic here
          {
            //example: you can move a legend item from one index to another here:
            LegendItem item = e.LegendItems[0];
            e.LegendItems.RemoveAt(0);
            e.LegendItems.Insert(anotherIndex, item);
          }
        }
      }
    }
