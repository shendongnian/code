      bool alwaysCancelAt30Seconds(int progress)
      {
           if ((DateTime.Now - startTime).TotalSeconds <= 30)
           {
                form1.lblProgress.Text = progress.ToString();
           } else
           {
                form1.lblProgress.Text = "canceled due to timeout!";
                return false;
           }
           return true;           
      }
      // call site:
      LongOperation(new [] { "some", "data" }, alwaysCancelAt30Seconds);
