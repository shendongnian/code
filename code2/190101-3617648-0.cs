    public interface IData
    {
        // properties and methods
    }
    public class Provider
    {
        public IData GetData()
        {
            return new Data();
        }
        private class Data : IData
        {
            // your implementation
        }
    }
