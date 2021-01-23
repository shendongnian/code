	[WebMethod]
	public static string LoadWidgetContent()
	{
		Page pageHolder = new Page();
		UserControl viewControl = (UserControl)pageHolder.LoadControl("~/WidgetContent/WidgetContent.ascx");
		pageHolder.Controls.Add(viewControl);
		StringWriter output = new StringWriter();
		HttpContext.Current.Server.Execute(pageHolder, output, false);
		return output.ToString();
	}
