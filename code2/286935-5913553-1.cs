    class Consumer
    {
        void CallService()
        {
            var context = new Context<int, int>()
            {
                InputValue = -1;
            }
            myService.SomeOperation(context);
            Console.WriteLine(context.OutputValue);
            foreach(string warning in context.Warnings)
                Console.Writeline(warning);
        }
    }
