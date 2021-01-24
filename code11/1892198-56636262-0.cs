    public static void YouTubeDownloaderWithProxy(string link, string path)
    {
        Process youTube = new Process();
        try
        {
            string code = link.Split('/').LastOrDefault();
            string proxy = @"http://....:8585/";
            string youtubeUrl = @"https://www.youtube.com/watch?v=" + "code";
            youTube.StartInfo.UseShellExecute = true;
            youTube.StartInfo.CreateNoWindow = false;
            youTube.StartInfo.FileName = Application.StartupPath + @"\youtube-dl.exe";
            youTube.StartInfo.Arguments = $"--proxy {proxy} -o '{path}' {youtubeUrl}";
            youTube.Start();
            youTube.WaitForExit();
            youTube.Dispose();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
    }
