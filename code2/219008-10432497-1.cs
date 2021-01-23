    private String BuildFormTitle()
    {
        String AppName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        String FormTitle = String.Format("{0} {1} ({2})", 
                                         AppName, 
                                         Application.ProductName, 
                                         Application.ProductVersion);
        return FormTitle;
    }
