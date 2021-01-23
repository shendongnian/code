    public static class Application {
       public static void Invoke ( EventHandler dothis ) {
          if ( dothis != null ){ 
             dothis( null, null ); }
       }
    }
