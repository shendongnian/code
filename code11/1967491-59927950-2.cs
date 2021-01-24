     private async void  button_download_image_Clicked(object sender, EventArgs e)
        {
            Uri image_url_format = new Uri("url");
            WebClient webClient = new WebClient();
            try
            {
                byte[] bytes_image = await webClient.DownloadDataTaskAsync(image_url_format);
                Stream image_stream = new MemoryStream(bytes_image);
                string dest_folder = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).ToString();
                string file_name = Path.GetFileName(image_url_format.LocalPath);
                string dest_path = Path.Combine(dest_folder, file_name);
                using (var fileStream = new FileStream(dest_path, FileMode.Create, FileAccess.Write))
                {
                    await image_stream.CopyToAsync(fileStream);
                }
            }
            catch (Exception ex)
            {
               await DisplayAlertAsync("Error", ex.ToString(), "OK");
            }
            await DisplayAlertAsync("Alert", "File scaricato con successo", "OK");
        }
