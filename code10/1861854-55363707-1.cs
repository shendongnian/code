    public class UtilityThing<T, I> where T : Thing<I>, new()
    {
        public T DoIt(SomeContext someContext, string name)
        {
            string contextVal = someContext.GetValue(name);
    
            var thing = new T { MyProperty = contextVal };
            return thing;
        }
    }
