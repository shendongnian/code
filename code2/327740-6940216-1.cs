    public class SomeObject
    {
        public SomeObject(IService service)
        {
        }
        public float Do(float x, float someValue)
        {
            return this.Service.Get(someValue) * x;
        }
    }
