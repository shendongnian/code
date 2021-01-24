    static async Task RunAsync()
        {
            string bookPath_Pdf = @"D:\VisualStudio\randomfile.pdf";
            string bookPath_xls = @"D:\VisualStudio\randomfile.xls";
            string bookPath_doc = @"D:\VisualStudio\randomfile.docx";
            string bookPath_zip = @"D:\VisualStudio\randomfile.zip";
            string format = "pdf";
            string reqBook = format.ToLower() == "pdf" ? bookPath_Pdf : (format.ToLower() == "xls" ? bookPath_xls : (format.ToLower() == "doc" ? bookPath_doc : bookPath_zip));
            string fileName = "sample." + format.ToLower();
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:49209/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("applicaiton/json"));
                    Console.WriteLine("GET");
                    //converting Pdf file into bytes array
                    var dataBytes = File.ReadAllBytes(reqBook);
                    //adding bytes to memory stream
                    var dataStream = new MemoryStream(dataBytes);
                    //send request asynchronously
                    HttpResponseMessage response = await client.GetAsync("api/person");
                    response.Content = new StreamContent(dataStream);
                    response.Content.Headers.ContentDisposition = new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment");
                    response.Content.Headers.ContentDisposition.FileName = fileName;
                    response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream");
                    //Check that response was successful or throw exception
                    //response.EnsureSuccessStatusCode();
                    //Read response asynchronously and save asynchronously to file
                    if (response.IsSuccessStatusCode)
                    {
                        using (Stream contentStream = await response.Content.ReadAsStreamAsync())
                        {
                            using (fileStream = new FileStream("D:\\VisualStudio\\randomfile.pdf", FileMode.Create, FileAccess.Write, FileShare.None))
                            {
                                //copy the content from response to filestream
                                await response.Content.CopyToAsync(fileStream);
                                //Console.WriteLine();
                            }   
                        }
                    }
               }
            }
            catch (HttpRequestException rex)
            {
                Console.WriteLine(rex.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
