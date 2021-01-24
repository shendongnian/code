    if (!Page.IsPostBack)
    {
       var count = 1;
       lblCount.Text = String.Format("Count: {0}", count);
       hdnCount.Value = count.ToString();
    }
    else
    {
       lblCount.Text = String.Format("Count: {0}", hdnCount.Value);
    }
