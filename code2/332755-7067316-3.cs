    public class BarFactory : IFactory<Bar>
    {
       public BarFactory () {}
       public Bar CreateItem(string s)
       {
          return new Bar(s);
       }
    }
