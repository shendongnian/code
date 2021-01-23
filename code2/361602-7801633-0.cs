    using System;
    using Clutter;
    
    namespace HelloWorld {
        public class HelloWorld {
            public int Main () {            
    
                // Init declaration produces error: 
                // Expression denotes a 'type', where a 'method group' was expected
                Clutter c = new Clutter();
                c.Init();
    
                Stage stage = Stage.Default;
                stage.Color = new Clutter.Color (0, 0, 0, 255);
                stage.SetSize (512, 512);
    
                stage.Show();
    
                // Main declaration produces error: 
                // Expression denotes a 'type', where a 'method group' was expected
                c.Main();
    
                return 0;
            }
        }
    }
