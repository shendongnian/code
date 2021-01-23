    private string getFileExtension(string mimetype)
    {
        mimetype = mimetype.Split('/')[1].ToLower();
        Hashtable hTable = new Hashtable();
        hTable.Add("pjpeg","jpg");
        hTable.Add("jpeg","jpg");
        hTable.Add("gif","gif");
        hTable.Add("x-png","png");
        hTable.Add("bmp","bmp");
        if(hTable.Contains(mimetype))
        {
            return (string)hTable[mimetype];
        }
        else
        {
            return null;
        }			
    }
