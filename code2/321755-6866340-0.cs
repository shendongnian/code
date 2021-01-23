    	private void webBrowser1_Navigating(object sender, WebBrowserNavigatingEventArgs e)
		{
			e.Cancel = true;
			WebClient client = new WebClient();
			client.DownloadDataCompleted += new DownloadDataCompletedEventHandler(client_DownloadDataCompleted);
			client.DownloadDataAsync(e.Url);
		}
		void client_DownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			string filepath = textBox1.Text;
			File.WriteAllBytes(filepath, e.Result);
			MessageBox.Show("File downloaded");
		}
