    class CommandWeather : ICommandAsync
    {
        public async Task Run(params string[] args)
        {
            //...
        }
        // Explicitly implement ICommand.Run
        void ICommand.Run(params string[] args)
        {
            //...
        }
    }
