    Interface IView {    
        List<string> Names {get; set;} 
    }
    
    public class Presenter {    
        public List<string> GetNames(IView view)    {
           return view.Names;    
        } 
    }
