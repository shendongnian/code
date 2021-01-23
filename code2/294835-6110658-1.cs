    public abstract class MyNumeric
    {
      public abstract object ValueObject { get; }
      public abstract MyNumeric Add(MyNumeric other);
      public abstract MyNumeric Substract(MyNumeric other);
      public abstract MyNumeric Multiply(MyNumeric other);
      public abstract MyNumeric Divide(MyNumeric other);
      public static MyNumeric operator +(MyNumeric a, MyNumeric b)
      {
        return a.Add(b);
      }
      public static MyNumeric operator -(MyNumeric a, MyNumeric b)
      {
        return a.Substract(b);
      }
      public static MyNumeric operator *(MyNumeric a, MyNumeric b)
      {
        return a.Multiply(b);
      }
      public static MyNumeric operator /(MyNumeric a, MyNumeric b)
      {
        return a.Divide(b);
      }
      //etc
    }
    public abstract class MyNumeric<T> : MyNumeric
      where T : struct
    {
      public override object ValueObject { get{ return this.Value;}}
      public new T Value { get; private set; }
      public MyNumeric(T value) { Value = value; }
    }
    public class MyInt : MyNumeric<int>
    {
      public MyInt(int value) : base(value) { }
      public override MyNumeric Add(MyNumeric other)
      {
        //could be really crafty here and use an interface instead that
        //gives access to the Value part only - that way you could
        //have MyDouble, for example, implement INumeric<int> explicitly 
        //via a c# explicit conversion.
        MyNumeric<int> otherInt = other as MyNumeric<int>;
        if (otherInt == null)
          throw new ArgumentException(
            "Need to handle numeric promotion/demotion for all types", "other");
        return new MyInt(Value + otherInt.Value);
      }
      public override MyNumeric Divide(MyNumeric other)
      {
        throw new NotImplementedException();
      }
      public override MyNumeric Multiply(MyNumeric other)
      {
        throw new NotImplementedException();
      }
      public override MyNumeric Substract(MyNumeric other)
      {
        throw new NotImplementedException();
      }
    }
    public class MyGeneric<TNumeric> where TNumeric : MyNumeric
    {
      public TNumeric WillNowCompile(TNumeric a, TNumeric b)
      {
        //cast is still required on the result.
        //however - you can set the return type to MyNumeric instead if you want.
        return (TNumeric)(a + b);
      }
      public TNumeric AnotherOne<TNumeric2>(TNumeric a, TNumeric2 b)
        where TNumeric2 : MyNumeric
      {
        return (TNumeric)(a / b);
      }
    }
