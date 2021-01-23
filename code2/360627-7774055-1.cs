    class abs<T> where T : IParsable<T>
    {
    //your implementation here
    }
    interface IParsable<T>
    {
       T Parse(string value);
    }
    public class Specific : IParsable<Specific>
    {
        public Specific Parse(string value)
        {
            throw new NotImplementedException();
        }
    }
