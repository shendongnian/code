    public interface IFactory<T>
    {
       T CreateItem(string s);
    }
    
    class Foo<TFactory,T> where TFactory : IFactory<T>, new()
    {
        private T CreateItem()
        {
            var factory = new TFactory();
            string s="";
            return factory.CreateItem(s);
        }
    }
