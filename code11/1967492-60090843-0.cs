    private void button_download_image_Clicked(object sender, EventArgs e)
    {
        Uri image_url_format = new Uri(image_url);
        WebClient webClient = new WebClient();
        try
        {
            byte[] bytes_image = webClient.DownloadData(image_url_format);
            Stream image_stream = new MemoryStream(bytes_image);
            string dest_folder = Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).ToString();
            string file_name = Path.GetFileName(image_url_format.LocalPath);
            string dest_path = Path.Combine(dest_folder, file_name);
            using (var fileStream = new FileStream(dest_path, FileMode.Create, FileAccess.Write))
            {
                image_stream.CopyTo(fileStream);
            }
            // this 3 lines fix my problem
            var mediaScanIntent = new Intent(Intent.ActionMediaScannerScanFile);
            mediaScanIntent.SetData(Android.Net.Uri.FromFile(new Java.IO.File(dest_path)));
            Android.App.Application.Context.SendBroadcast(mediaScanIntent);
        }
        catch (Exception ex)
        {
            DisplayAlert("Error", ex.ToString(), "OK");
        }
        DisplayAlert("Alert", "File scaricato con successo", "OK");
    }
    
