    foreach(string path in this.PathsJPG) {
        currentpath = path;
        pd.PrintPage += PrintPage;
        pd.EndPrint += (o,e) => { File.Delete(path); }
        pd.Print();
    }
