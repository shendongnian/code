    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        String output_dir = "C:\\OUTPUT\\";
        String output_file = Path.Combine(output_dir, e.Name);
        while (true)
        {
            try
            {
                File.Move(e.FullPath, output_file);
                break;
            }
            catch (IOException)
            {
                //sleep for 100 ms
                System.Threading.Thread.Sleep(100);
            }
        }        
        eventLog1.WriteEntry("moving file to " + output_file);
    }
