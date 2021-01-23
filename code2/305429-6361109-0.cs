        interface ICommand
        {
            void Print();
        }
        class CommandA : ICommand
        {
            public void Print() { Console.WriteLine("A"); }
        }
        class CommandB : ICommand
        {
            public void Print() { Console.WriteLine("B"); }
        }
        public static void Main()
        {
            var actions = new List<Action>();
            foreach (var command in new ICommand[]{
                        new CommandA(), new CommandB(), new CommandB()})
            {
                var commandcopy = command;
                actions.Add(() => commandcopy.Print());
            }
            foreach (var action in actions)
                action();
        }
