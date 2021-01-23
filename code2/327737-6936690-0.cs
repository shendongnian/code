    public class SomeObjectFactory : ISomeObjectFactory
    {
        public ISomeObject Create(float someValue)
        {
            var service = yourContainer.Get<IYourService>();
            return new SomeObject(service, someValue);
        }
    }
