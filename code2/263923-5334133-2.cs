    public class Invoker
    {
         protected List<dynamic> _objects = null;
         protected Action<dynamic> _method = null;
         public Invoker()
         {
             _objects = new List<dynamic>();
         }
         public void Bind(dynamic actual)
         {
              _objects.Add(actual);
         }
         public void SetDelegate<T>(Action<T> action)
         {
             _method = action; // should work due to covariant type assignment
         }
         public void DynamicInvoke()
         {
             _objects.ForEach(x => _method(x));
         }
    }
    Invoker x = new Invoker();
    x.SetDelegate<SomeTypeForIntellisense>((obj) => obj.SomeProperty = 123);
    x.Bind(new ExpandoObject());
    x.DynamicInvoke();
