    abstract class Process {
        abstract void Start();
        abstract void Stop();
    }
    class Program {
        private static Dictionary<Type, Process> Processes;
        
        public static Main {
            
            // Initialize all 40 objects
            Processes = new Dictionary <Type, Process> () {
                { typeof(ProcessX), new ProcessX },
                { typeof(ProcessY), new ProcessY }
            };
            
            // Start them all. This could be moved to a function.
            foreach ( var process in Processes ) {
                process.Start();
            }
            while ( running ) {
            } 
           
            // Stop or cancel a specific process by type.
            Stop<ProcessX>();
            
            // or stop all processes
            foreach( var process in Processes ) {
                process.Stop();
            }
        }
        public static void Stop<T> () {
            if ( Processes.TryGetValue ( typeof(T), out Process process) ) {
                process.Stop();
            }
        }
    }
