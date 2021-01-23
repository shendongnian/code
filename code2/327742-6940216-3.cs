    public class SomeObject
    {
        private float someValue
        public SomeObject(IService service, float someValue)
        {
            this.someValue = someValue
        }
        public float Do(float x)
        {
            return this.Service.Get(this.someValue) * x;
        }
    }
