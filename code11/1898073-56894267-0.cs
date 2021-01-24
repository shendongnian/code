    // Add Reference Shell32.DLL
    string sFolder = "e:\\";
    string sFile= "01. IMANY - Don't Be so Shy (Filatov & Karas Remix).mp3";
    List<string> arrProperties = new List<string>();
    Shell objShell = new Shell();
    Folder objFolder;
    objFolder = objShell.NameSpace(sFolder);
    int nMaxProperties = 332;
    for (int i = 0; i < nMaxProperties; i++)
    {
        string sHeader = objFolder.GetDetailsOf(null, i);
        arrProperties.Add(sHeader);
    }
    FolderItem objFolderItem = objFolder.ParseName(sFile);
    if (objFolderItem != null)
    {
        for (int i = 0; i < arrProperties.Count; i++)
        {
            Console.WriteLine((i + ('\t' + (arrProperties[i] + (": " + objFolder.GetDetailsOf(objFolderItem, i))))));
        }
    }
