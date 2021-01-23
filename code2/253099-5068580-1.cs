    using System;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static bool _cancelled = false;
            static void Main( string[] args )
            {
                var computationTask = Task.Factory.StartNew(PerformIncredibleComputation);
                var acceptCancelKey = Task.Factory.StartNew(AcceptCancel);
            
            while (!acceptCancelKey.IsCompleted && ! computationTask.IsCompleted)
            {
                
                computationTask.Wait (100);        
            }
            if( acceptCancelKey.IsCompleted && !computationTask.IsCompleted )
            {
                computationTask.Wait (new System.Threading.CancellationToken ());
            }
            else if(!acceptCancelKey.IsCompleted)
            {
                acceptCancelKey.Wait(new System.Threading.CancellationToken());
            }
        }
        private static void PerformIncredibleComputation()
        {
            Console.WriteLine("Performing computation.");
            int ticks = Environment.TickCount;
            int diff = Environment.TickCount - ticks;
            while (!_cancelled && diff < 10000)
            {
               //computing  
            }
            Console.WriteLine("Computation finished");
        }
        private static void AcceptCancel()
        {
            var key = Console.ReadKey(true);
            Console.WriteLine("Press Esc to cancel");
            while(key.Key != ConsoleKey.Escape)
            {
                key = Console.ReadKey(true);
            }
            _cancelled = true;
            Console.Write("Computation was cancelled");
            
        }
    }
}
