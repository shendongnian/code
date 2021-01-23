    class Program
    {
        private static IList<Action> _actions;
        static void Main(string[] args)
        {
            _actions = new List<Action>
                       {
                           () => {
                               //do thing 
                           },
                           () => {
                               //do thing 
                           },
                           () => {
                               //do thing 
                           },
                           () => {
                               //do thing 
                           },
                       };
            foreach (var action in _actions)
            {
                action();
            }
        }
    }
    
