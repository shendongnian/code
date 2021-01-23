    public class InvariantException : MyAppException
    {
        public object FailingObject = null;
        public ModelStateDictionary ModelState = new ModelStateDictionary();
        public InvariantException() { }
        public InvariantException(object failingObject, ModelStateDictionary messages)
        {
            this.FailingObject = failingObject;
            this.ModelState = messages;
        }
        public InvariantException(object failingObject, ModelStateDictionary messages,
            Exception innerException)
            : base("refer to ModelState", innerException)
        {
            this.FailingObject = failingObject;
            this.ModelState = messages;
        }
    }
