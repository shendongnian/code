    private void chart1_AxisScrollBarClicked(object sender, ScrollBarEventArgs e)
    {
      Boolean blnIsXaxisReset = false;
      try
      {
        // Handle zoom reset button
        if(e.ButtonType == ScrollBarButtonType.ZoomReset)        
        {
          // Event is handled, no more processing required
          e.IsHandled = true;
          // Reset zoom on Y axis
          while (chart1.ChartAreas[0].AxisY.ScaleView.IsZoomed)
            chart1.ChartAreas[0].AxisY.ScaleView.ZoomReset();
          //Handles Zoom reset on X axis with scroll bar
          foreach (Series series in chart1.Series)
          {
            if (series.YAxisType == AxisType.Secondary)
            {
              chart1.ChartAreas[0].AxisX.ScaleView.Zoom(-10, 10);
              blnIsXaxisReset = true;
              break;
            }
          }
          //Handles Zoom reset on ordinary X axis
          if (blnIsXaxisReset == false)
          {
            while (chart1.ChartAreas[0].AxisX.ScaleView.IsZoomed)
              chart1.ChartAreas[0].AxisX.ScaleView.ZoomReset();
          }
        }
      }
      catch (Exception ex)
      {
        BuildException buildException = new BuildException();
        buildException.SystemException = ex;
        buildException.CustomMessage = "Error in zooming the Chart";
        ExceptionHandler.HandleException(buildException);
      }
    }
