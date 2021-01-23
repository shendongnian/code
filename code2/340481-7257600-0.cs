    string [] file_list;
    int i = 0;
    file_list = Directory.GetFiles(MyProg.Common.GetDirectory(),
                                   MyProg.Common.GetFileNameRoot() + "*.*");
    // it is possible that file_list is null
    // potentially due to an invalid path (missing / perhaps?)
    foreach (string filename in file_list)
    {
        string filenameonly = Path.GetFileName (filename);
        // It's possible that the MixedZone.Kernel.Common library
        // is experiencing the null reference exception because it
        // may not understand what file to get the name root of or 
        // maybe it is not capable of getting the root for some
        // other reason (permissions perhaps?)
        if (filenameonly == MixedZone.Kernel.Common.GetFileNameRoot() + "runlog.log")
        {
            nametextbox.Text = filenameonly;
        }
