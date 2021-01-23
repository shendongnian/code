    public class CoffeeMachine
    {
        private readonly TaskScheduler scheduler;
        public CoffeeMachine()
        {
            this.scheduler = new SingleThreadTaskScheduler();
        }
        public Task<Coffee> MakeCoffeeAsync()
        {
            return Task.Factory.StartNew<Coffee>(
                this.MakeCoffee,
                CancellationToken.None,
                TaskCreationOptions.None,
                this.scheduler);
        }
        private Coffee MakeCoffee()
        {
            // this method will always execute on the same thread
        }
    }
