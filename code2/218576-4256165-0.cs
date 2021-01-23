    // in a codebehind for example:
    protected string isVisible;
    public void Page_Load(Object sender, EventArgs e)
    {
      // assign the IsDefault value for database say:
      string IsDefault = "...";
      isVisible = (IsDefault == "True") ? "False" : "True";
    }
   
    // ...and in the web form:
    Visible="<%= isVisible %>">
