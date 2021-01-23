    class Program {
      static void Fun() {
        new Program(); 
      }
      static Program() {
        Fun();
      }
    }
