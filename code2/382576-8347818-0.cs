    public class WcfLoader {
       static WcfLoader _instance;
       public WcfLoader() {
          if ( _instance == null ) {
             // do the initialization
             _instance = this; 
          }
       } 
    }
