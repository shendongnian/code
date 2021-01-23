	using (SPSite site = new SPSite("http://localhost"))
	{
		using (SPWeb web = site.OpenWeb())
		{
			SPContentType ct = web.ContentTypes[SPBuiltInContentTypeId.Document];
			SPField fld = web.Fields.GetField(fldName);
			SPFieldLink lnk = new SPFieldLink(fld);
			ct.FieldLinks.Add(lnk);
			ct.Update(true);
		}
	}
