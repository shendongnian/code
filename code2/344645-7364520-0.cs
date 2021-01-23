    public enum PageNameProperty { MasterPage , SearchResultsPage, MLIPage };  
    private PageNameProperty pageName;
    
    public PageNameProperty PageName 
    { 
       get
       {
           return pageName ?? PageNameProperty.MLIPage;
       }
       set
       {
           pageName = value;
       }
    } 
