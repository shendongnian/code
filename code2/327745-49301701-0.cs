    public class SomeObject
    {
        private readonly IService _service;
        public SomeObject(IService service)
        {
            // constructor only captures dependencies
            _service = service;
        }
        public SomeObject Load(float someValue)
        {
            // real initialization goes here
            // ....
            // you can make this method return no value
            // but this makes it more convienient to use
            return this;
        }
    }
