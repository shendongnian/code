    try
    {
       File.Copy(myLocalFile, myNetworkFile);
    }
    catch (IOException ioEx)
    {
       Debug.Write(myLocalFile + " failed to copy!  Try again or copy later?");
    }
