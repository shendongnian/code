    private static string _muiUrl;
    public static string MUIUrl
    {
        get
        {
            //if the variable is null or empty
            if (String.IsNullOrEmpty(_muiUrl))
            {
                //using defines a scope, outside of which an object or objects will be disposed.
                //http://msdn.microsoft.com/en-us/library/yh598w02(v=vs.80).aspx
                using (var db = new IntLMPDB())
                {
                    //this is linq
                    //a simple example will be 
                    //http://stackoverflow.com/questions/214500/which-linq-syntax-do-you-prefer-fluent-or-query-expression
                    _muiUrl = (from c in db.Control 
                                where c.ControlKey == "MUI_Url" 
                                select c.ControlValue
                              ).FirstOrDefault();
                    //or another linq syntax will be
                    //_muiUrl= db.Control
                    //        .Where(c => c.ControlKey == "MUI_Url")
                    //        .FirstOrDefault()
                    //        .ControlValue;
                }
            }
            return _muiUrl;
        }
    }
