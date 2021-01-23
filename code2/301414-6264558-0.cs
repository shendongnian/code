    public class A
    {
      public static A Parse(string){}
    }
    public class Unsupported { }
    public class Generic<T> : where T has T Parse(string)
    {
       //the impossible generic constraint above /|\
       //                                         |
       public T SomeFunction(string input){
         //if you could do it:
         T toReturn = T.Parse(input);
       }
    }
    public Generic<A> a; //would compile in this fantasy world :)
    public Generic<Unsupported> b; //would not compile in this fantasy world
