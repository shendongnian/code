    public void SendProcess(string md5, string procName, string procLoc)
    {
        var values = new NameValueCollection
                     {
                         { "MD5",      md5      },
                         { "procName", procName },
                         { "procLoc",  procLoc  },
                         { "userID",   _userID  },
                     };
        using (var client = new WebClient())
        {
            client.UploadValues("http://localhost/EDAC/SubmitProc.php", values);
        }
    }
