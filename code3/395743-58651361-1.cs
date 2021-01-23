	using System;
	using Microsoft.Office.Interop.PowerPoint;
	using System.Reflection;
	class PowerPointConverterDocumentPropertiesReaderWriter
	{
		static void Main()
		{
			Application pptApplication = new Application();
			Presentation presentation = pptApplication.Presentations.Open("presentation.pptx");
			object docProperties = presentation.BuiltInDocumentProperties;
			string title = GetDocumentProperty(docProperties, "Title").ToString();
			string subject = GetDocumentProperty(docProperties, "Subject").ToString();
			string author = GetDocumentProperty(docProperties, "Author").ToString();
			string category = GetDocumentProperty(docProperties, "Category").ToString();
			string keywords = GetDocumentProperty(docProperties, "Keywords").ToString();
			SetDocumentProperty(docProperties, "Title", "new title");
			SetDocumentProperty(docProperties, "Subject", "new subject");
			SetDocumentProperty(docProperties, "Author", "new author");
			SetDocumentProperty(docProperties, "Category", "new category");
			SetDocumentProperty(docProperties, "Keywords", "new keywords");
		}
		static object GetDocumentProperty(object docProperties, string propName)
		{
			object prop = docProperties.GetType().InvokeMember(
				"Item", BindingFlags.Default | BindingFlags.GetProperty,
				null, docProperties, new object[] { propName });
			object propValue = prop.GetType().InvokeMember(
				"Value", BindingFlags.Default | BindingFlags.GetProperty,
				null, prop, new object[] { });
			return propValue;
		}
		static void SetDocumentProperty(object docProperties, string propName, object propValue)
		{
			object prop = docProperties.GetType().InvokeMember(
				"Item", BindingFlags.Default | BindingFlags.GetProperty,
				null, docProperties, new object[] { propName });
			prop.GetType().InvokeMember(
				"Value", BindingFlags.Default | BindingFlags.SetProperty,
				null, prop, new object[] { propValue });
		}
	}
