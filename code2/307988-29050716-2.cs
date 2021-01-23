    /// <summary>
    /// Page init event, setup the core of the page.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected override void Page_Init(object sender, EventArgs e)
    {
      try
      {
        // See if we're in a postback.
        if (IsPostBack)
        {
          // If we have a target...
          if (Request.Params["__EVENTTARGET"] != null)
          {
            // See what the target is.
            switch (Request.Params["__EVENTTARGET"])
            {
              case "btnGo":
                // Maybe make this a parameterless method rather than an event handler to avoid parameters that you don't need.
                btnGo_Click(null, null);
              break;
            }
          }
        }
      }
    }
