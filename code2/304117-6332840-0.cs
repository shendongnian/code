    public interface IDrilldown
    {
       void AddCriteria<T>(T Criterion);
    }
    
    public class MyClass : IDrilldown
    {
        void IDrilldown.AddCriteria<T>(T Criterion)
        {
           dynamic value = Criterion;
           // can use typeof() to figure out type if needed...
           ...
        }
    }
