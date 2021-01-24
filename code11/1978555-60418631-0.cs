    public class SomeServiceThing: Singleton<SomeServiceThing>
    {
        private Queue<ISomeType> = new Queue<ISomeType>();
        ....
        private void EnqueueEvent<T>(ISomeType _event)
        {
