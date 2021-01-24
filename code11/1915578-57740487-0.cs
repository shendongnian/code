    private async void BtnUploadInvoices_Click(object sender, EventArgs e)
        {
            string[] filenames = Directory.GetFiles("D:\\test")
                                     .Select(Path.GetFullPath)
                                     .ToArray();
            await UploadFileAsync(filenames);
            //Folder Creation
            if (!Directory.Exists(@"D:/" + "ProcessedFiles"))
                Directory.CreateDirectory(@"D:/" + "ProcessedFiles");
            if (Directory.Exists("D:\\test"))
            {
                foreach (var file in new DirectoryInfo("D:\\test").GetFiles())
                {
                    if(file.Exists!=true)
                    {
                        file.MoveTo($@"{"D:\\ProcessedFiles"}\{file.Name}");
                    }
                    else
                    {
                        MessageBox.Show(file.Name + "already exists");
                    }
                    
                }
            }
        }
        public static async Task UploadFileAsync(string[] files)
        {
            if(files.Count()!=0)
            {
                HttpClient client = new HttpClient();
                // we need to send a request with multipart/form-data
                var multiForm = new MultipartFormDataContent();
                string fileMimeType = "";
                // add file and directly upload it
                for (int i = 0; i < files.Count(); i++)
                {
                    FileStream fs = File.OpenRead(files[i]);
                    var streamContent = new StreamContent(fs);
                    if (Path.GetExtension(files[i]) == ".pdf")
                        fileMimeType = "application/pdf";
                    else
                        fileMimeType = "application/xml";
                    //string dd = MimeType(path);
                    var imageContent = new ByteArrayContent(streamContent.ReadAsByteArrayAsync().Result);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(fileMimeType);
                    //imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                    multiForm.Add(imageContent, "files", Path.GetFileName(files[i]));
                    fs.Close();
                }
                // send request to API
                var url = "https://localhost/api/getDocuments";
                var response = await client.PostAsync(url, multiForm);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Success");
                }
                else
                {
                    MessageBox.Show(response.ToString());
                }
            }
            else
            {
                MessageBox.Show("There are no files in the folder to process");
            }
            
        }
