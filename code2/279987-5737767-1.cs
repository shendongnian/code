    /// <SUMMARY>
    /// Overriding the InitializeCulture method to set the user selected
    /// option in the current thread. Note that this method is called much
    /// earlier in the Page lifecycle and we don't have access to any controls
    /// in this stage, so have to use Form collection.
    /// </SUMMARY>
    protected override void InitializeCulture()
    {
        ///<remarks><REMARKS>
        ///Check if PostBack occured. Cannot use IsPostBack in this method
        ///as this property is not set yet.
        ///</remarks>
        if (Request[PostBackEventTarget] != null)
        {
            string controlID = Request[PostBackEventTarget];
            if (controlID.Equals(CountryDropDownName))
            {
                string selectedValue =
                       Request.Form[Request[PostBackEventTarget]];
               **//Bind your control here based on the countryID.**
            }
        }
        base.InitializeCulture();
    }
