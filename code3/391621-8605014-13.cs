    public class DoingThings : IDoThings
    {
        private readonly ICommandBus commandBus;
        private readonly IObjectRepository objectRepository;
        public DoingThings(ICommandBus commandBus,
            IObjectRepository objectRepository)
        {
            this.commandBus = commandBus;
            this.objectRepository = objectRepository;
        }
        public void DoThings()
        {
            var objects = objectRepository.getAll();
            
            foreach (Thing thing in objects)
            {
                thing.modifiedOn = DateTime.Now;
                objectRepository.Update(thing);
            }
        }
    }
