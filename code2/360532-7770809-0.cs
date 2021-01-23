     public Assembly GetPageAssembly()
     {
       var pageType = Page.GetType();
       return Assembly.GetAssembly(pageType.BaseType == null 
                                    || pageType.BaseType == typeof (Page)
                                         ? pageType : pageType.BaseType);
     }
