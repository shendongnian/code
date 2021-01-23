    string s = "";
    private void CheckLog()
    {
        bool _found;
        while (true)
        {
            _found = false;
            Thread.Sleep(5000);
            if (!System.IO.File.Exists("Command.bat")) continue;
            using (System.IO.StreamReader sr = System.IO.File.OpenText("Command.bat"))
            {
                //s = "VALUE";
                while ((s = sr.ReadLine()) != null)
                {
                    if (s.Contains("mp4:production/CATCHUP/"))
                    {
                        _found = true;
                        break;
                    }
                }
            }
        }
    }
