          class Program {
               static void Main() {
                    var a = new Program( "asdf" );
                    var b = new Program( "" );
                    var c = new Program( null );
               } // <-- breakpoint here
     
               string _data;
               public Program( string data ) {
                    _data = data;
               }
     
               public override string ToString() {
                    return _data;
               }
          }
