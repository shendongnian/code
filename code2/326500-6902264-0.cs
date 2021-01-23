    public Control FindInnerControl  (string id)
    {
      if (contentHolder.Controls.Count > 0)
      {
        return contentHolder.Controls [0].FindControl (id); //The first control is your ContentContainer
      }
      return null;
    }
