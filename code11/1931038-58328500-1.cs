    namespace TestDelegate
    {
        public delegate Task SendResult(int i);
        public class Add
        {   
            public SendResult WhereToSend;
    
            public async Task Calculate (int number)
            {
                Console.WriteLine("Entered");
                int result = number + number;
                await WhereToSend (result);
            }
        }
    }
    
    
    namespace TestStuff
    {
        class Program
        {
    
            static void Main(string[] args)
            {   
                Add obj = new Add();
                obj.WhereToSend = DisplayAdd;
                Console.WriteLine("Started Calculating");
                obj.Calculate(10).Wait();
            }
    
            static async Task DisplayAdd(int value)
            {
                // Some awaitable operation like below as per your business logic
                await Task.Delay(1);
                Console.WriteLine(value);
            }
    
        }
    }
