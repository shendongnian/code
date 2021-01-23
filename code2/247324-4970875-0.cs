	bool valid = true;
	/* Only check Page.IsValid for USCulture, for other cultures MaskedEditValidator only properly works on the client-side 
	 * (shows IsValid == false) on the server even though the date is in correct format and passed client side validation. */
	if (USCulture)
	{
		valid = Page.IsValid;
	}
	else
	{
		/* Even though we are not checking Page.IsValid for non-us cultures, the server will trigger the validation anyway and on the 
		 * postback the error message will display.  Here we simply set the .Text property to a HTML comment, for the browser to render nothing
		 * as if there is no error.  Setting this property to empty/null causes the control to revert to the original message specified in .aspx. */
		mevCalendar.Text = "<!>";
	}
	if (valid)
	{
		BindGridDataSource(pageNumber);
	}
