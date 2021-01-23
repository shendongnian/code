     public class Foo {
        public static Foo Global = new Foo ();
        public Foo () { }
        // rest of Foo logic
     }
    
     public class Program {
       static void Main () {
          MainForm = new MainForm (Foo.Global);
       }
     }
