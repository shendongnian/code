				// Create a new WebClient instance.
				using (WebClient myWebClient = new WebClient())
				{
					// Download the Web resource and save it into a data buffer.
					byte[] bytes = myWebClient.DownloadData(body.SourceUrl);
					MemoryStream memoryStream = new MemoryStream(bytes);
					// Open a WordprocessingDocument for read-only access based on a stream.
					using (WordprocessingDocument wordDocument = WordprocessingDocument.Open(memoryStream, false))
					{
						MainDocumentPart mainPart = wordDocument.MainDocumentPart;
						content = mainPart.Document.Body.InnerText;
					}
				}
