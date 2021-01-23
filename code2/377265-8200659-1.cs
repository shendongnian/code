            string url = "http://..."; // Change this to the full url of the file you want to download 
            string filename = "downloadedfile.zip"; // Change this to the filename you want to save it as locally.
            WebClient client = new WebClient(); 
			try 
            {
                Uri uri = new Uri(url);
                client.Headers.Add("Accept: text/html, application/xhtml+xml, */*");
                client.Headers.Add("User-Agent: Mozilla/5.0 (compatible; MSIE 9.0; Windows NT 6.1; WOW64; Trident/5.0)");
				client.DownloadFileAsync(uri, filename);
                while (client.IsBusy)
                {
                    System.Threading.Thread.Sleep(1000);
                }
			}
			catch (UriFormatException ex) 
            {
				Console.WriteLine(ex.Message);
			}
