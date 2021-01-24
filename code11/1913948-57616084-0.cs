lang-csharp
private void Upload(string fileName)
{
	var client = new WebClient();
	client.UploadFileCompleted += Client_UploadFileCompleted;
	try
	{
		var uri = new Uri("https://saas-dev/api/getDocs");
		{
		   client.Headers.Add("fileName", System.IO.Path.GetFileName(fileName));
		   client.UploadFileAsync(uri, fileName);
		}
	}
	
	catch (Exception ex)
	{
		MessageBox.Show(ex.Message);
	}
}
private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
{
   // Check e.Error for errors
}
