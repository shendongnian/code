    string [] file_list;
    int i = 0;
    file_list = Directory.GetFiles(MyProg.Common.GetDirectory(),
                                   MyProg.Common.GetFileNameRoot() + "*.*");
    if (file_list == null) throw new Exception("File List is null. Something is wrong.");
    foreach (string filename in file_list)
    {
        string filenameonly = Path.GetFileName (filename);
        string fileroot = MixedZone.Kernel.Common.GetFileNameRoot();
        if(string.IsNullOrEmpty(fileroot) throw new Exception("MixedZone Library failed.");
        if (filenameonly.Equals(fileroot + "runlog.log", StringComparison.OrdinalIgnoreCase)) // Choose your own string comparison here
        {
            nametextbox.Text = filenameonly;
        }
