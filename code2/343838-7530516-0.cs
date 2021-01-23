    System.Threading.Timer tFileWatcher;
    private string fileTime1 = "";
    private string fileTime2 = "";
    //
    private void Form1_Load(object sender, EventArgs e)
        {
            tFileWatcher = new System.Threading.Timer(ComputeBoundOp2, 0, 0, 500);
            fileTime1 = File.GetLastWriteTime(fileInfo).ToFileTime().ToString();
            fileTime2 = File.GetLastWriteTime(fileInfo).ToFileTime().ToString();
        }
    private void ComputeBoundOp2(Object state)
        {
            fileTime2 = File.GetLastWriteTime(fileInfo).ToFileTime().ToString();
            
            if (fileTime1 != fileTime2)
            {
            //Do something
            }
        }
