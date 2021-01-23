    #if DEBUG
        string path = Server.MapPath("~/myproj.WhatDoIHave.txt");
        string whatDoIHave = ObjectFactory.WhatDoIHave();
        File.WriteAllText(path, whatDoIHave);
    #endif
