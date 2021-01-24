     var streamFile = await graphClient.Me.Drive.Items["item-id"].Content.Request().GetAsync();
	  byte[] buffer = new byte[16 * 1024];
	  try
	  {
		PdfReader pdfReader = null;
		PdfStamper pdfStamper = null;
		using (MemoryStream ms = new MemoryStream())
		{
		  int read;
		  while ((read = streamFile.Read(buffer, 0, buffer.Length)) > 0)
		  {
			ms.Write(buffer, 0, read);
		  }
		  pdfReader = new PdfReader(ms.ToArray());
		  pdfStamper = new PdfStamper(pdfReader, ms);
		  
			AcroFields fields = pdfStamper.AcroFields;
		  fields.SetField("Full_Names", "JIMMMMMMAYYYYY");
		  await graphClient.Me.Drive.Items["item-id"].ItemWithPath("NewDocument-2.pdf").Content.Request().PutAsync<DriveItem>(ms);
		}
	  }
	  finally
	  {
		if (pdfReader != null) pdfReader.Dispose();
		if (pdfStamper != null) pdfStamper.Dispose();
	  }
