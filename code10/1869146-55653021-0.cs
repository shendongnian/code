    SAS.Workspace ws = new Workspace();
    LanguageService ls = ws.LanguageService;
    StoredProcessService sp = ls.StoredProcessService;
    sp.Repository = @"file:" + @"x:\temp";
    sp.Execute("test.sas", string.Empty);
    string log = ls.FlushLog(1000);
