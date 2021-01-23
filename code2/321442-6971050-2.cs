    public string Error(Exception pException, string pFriendlyMessage, Control errorParent)
    {
        using (BusError erro = new BusError())
        {
            int? errorId = //HERE Routine to log the error;
            Literal errorControl = new Literal();
            errorControl.Text = String.Format("<div class=\"errorMain\"><p>{0}</p><small>Event Tracker: {1}</small></div>", pFriendlyMessage, errorId);
            errorParent.Controls.AddAt(0, errorControl);
        }
    }
