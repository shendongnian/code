	System.Security.Principal.WindowsImpersonationContext impersonationContext;
	impersonationContext = 
		((System.Security.Principal.WindowsIdentity)User.Identity).Impersonate();
		
		using (var doc = new HtmlWordDocument(outFile))
		{
			// calls Selection.InsertFile( file )
			doc.WriteContent(tempFile);
			// calls document.SaveAs()
			doc.Save();
		}
	impersonationContext.Undo();
