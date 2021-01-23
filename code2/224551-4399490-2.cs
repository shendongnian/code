    public interface ISanitizer<T, TA>
    {
        T Sanitize(TA data);
    }
    public class BasicFilenameSanitizer<T, TA> : ISanitizer<T, TA>
    {
        public virtual T Sanitize(TA data)
        {
            throw new NotImplementedException();
        }
    }
    public class Test : BasicFilenameSanitizer<int, string>
    {
        public override int Sanitize(string data)
        {
            return data.Length;
        }
        // a little test func...
        public void TestFunc()
        {
            int result = this.Sanitize("fred");
        }
    }
