    interface IForm1Factory
    {
        Form1 Create(int valueToEdit);
    }
    
    class Form1Factory
    {
        public readonly ILogger _processRepository;
        public readonly Icopy _copy;
        
        public Form1Factory(ILogger logger, ICopy copy)
        {
            this._processRepository = logger;
            this._copy = copy;
        }
    
        public Form1 Create(int valueToEdit)
        {
            return new Form1(valueToEdit, _processRepository, _copy);
        }
    }
