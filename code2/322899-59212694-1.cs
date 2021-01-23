    class Program {
        static void Main(string[] args) {
            IMachine machine = new Machine();
            machine.Run();
            Console.ReadKey();
        }
        
    }
    class Machine : IMachine {
        private void Run() {
            Console.WriteLine("Running...");
        }
        void IMachine.Run() => Run();
    }
    interface IMachine
    {
        void Run();
    }
