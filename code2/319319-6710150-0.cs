    //Create Thumbs
    string thumbpath, thumbname;
    string thumbargs;
    string thumbre;
    thumbpath = AppDomain.CurrentDomain.BaseDirectory + "Video\\Thumb\\";
    thumbname = thumbpath + withoutext + "%d" + ".jpg";
    thumbargs = "-i " + inputfile + " -vframes 1 -ss 00:00:07 -s 150x150 " + thumbname;
    Process thumbproc = new Process();
    thumbproc = new Process();
    thumbproc.StartInfo.FileName = spath + "\\ffmpeg\\ffmpeg.exe";
    thumbproc.StartInfo.Arguments = thumbargs;
    thumbproc.StartInfo.UseShellExecute = false;
    thumbproc.StartInfo.CreateNoWindow = false;
    thumbproc.StartInfo.RedirectStandardOutput = false;
    try
    {
    thumbproc.Start();
    }
    catch (Exception ex)
    {
    Response.Write(ex.Message);
    }
    thumbproc.WaitForExit();
    thumbproc.Close();
