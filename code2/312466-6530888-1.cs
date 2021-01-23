    public class IndexViewModel {
       
       public IndexViewModel() 
       {
           PageMeta = new PageMeta();
           Q = new Q();
           T = new T();
       }
       public PageMeta PageMeta { get; set; }
       public T Test { get; set; }
       public Q Que { get; set; }
    }
