    private ContentMode GetContentMode(){
    }
    
    private Content GetContent(int id){
    }
    private Content GetContent(HttpRequest request){
       return GetContent(Convert.ToInt64(request.QueryString["id"]));
    }
    
    private void InitContent(){
      ContentMode mode = GetContentMode();
      Content = null;
      switch(mode){
        case ContentMode.Query:
           GetContent(Request);
           break;
        case ContentMode.Default:
           GetContent(DefaultId);
           break;
        case ContentMode.None:
           ... handle none case...
           break;
    
      }
    }
