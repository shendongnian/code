    System.IO.IsolatedStorage.IsolatedStorageFile iso = System.IO.IsolatedStorage.IsolatedStorageFile.GetUserStoreForApplication(); 
    using (checkbookDB.Log = new System.IO.StreamWriter(iso.CreateFile("log.txt"))) 
    { 
    }
 
