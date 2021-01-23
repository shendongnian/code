        string strpath = Server.MapPath("~/Data/SPLIT/DATA.TXT");
        string newFile = Server.MapPath("~/Data/SPLIT");
        if (System.IO.File.Exists(@strpath))
        {
            Split(strpath, newFile+"\\{0}.CSV");
        }
