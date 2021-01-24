    public class Controller
    {
        public Controller(IService<MessageA> serviceA, IService<MessageB> serviceB)
        {
            this._serviceA = serviceA;
            this._serviceB = serviceB; 
        }
        private readonly IService<MessageA> _serviceA;
        private readonly IService<MessageB> _serviceB;
        public void Do()
        {
            IService<MessageA> serviceA = this._serviceA;
        }
    }
