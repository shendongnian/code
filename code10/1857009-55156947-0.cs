    namespace Mini.Models
    {
        public class Auto
        {
            // code and stuff
        }
    }
    
    namespace Mini.Models
    {
        public class Airplane
        {
            // code and stuff
        }
    }
    
    namespace Mini.Auto
    {
        public class OtherAirplane
        {
            // code and stuff
        }
    }
    
    namespace Mini
    {
        using Mini.Models;
        using namespaceAuto = Auto ; /// this also not fix the issue.
    
        class NamespaceIssue
        {
            void execute()
            {
                var autoObject = new Auto();   // Error 
                var planeObject = new Airplane();  // Same folder but not referencing Models in front of it      
                // other code
            }
        }
    }
