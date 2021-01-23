    public struct TState
    {
       public static TState Active = new TState('A');
       public static TState Pending = new TState('P');
    
       private char _value;
    
       public TState(char value)
       {
          switch (value)
          {
             case 'A':
             case 'P':
                this._value = value;  // Known values
                break;
             default:
                this._value = 'A';    // Default value
                break;
          }
       }
    
       public static implicit operator TState(char value)
       {
          switch (value)
          {
             case 'A':
                return TState.Active;
             case 'P':
                return TState.Pending;
          }
          throw new InvalidCastException();
       }
    
       public static implicit operator char(TState value)
       {
          return value._value;
       }
    
       public override string ToString()
       {
          return this._value.ToString();
       }
    }
    
    public class Test { public TState Value { get; set; } }
    
    class Program
    {
       static void Main(string[] args)
       {
          Test o = new Test();
          o.Value = 'P';               // From Char
          char c = o.Value;            // To Char
          Console.WriteLine(o.Value);  // Writes 'P'
          Console.WriteLine(c);        // Writes 'P'
    
          JavaScriptSerializer jser = new JavaScriptSerializer();
          Console.WriteLine(jser.Serialize(o));  // Writes '{"Value":{}}'
    
          Console.ReadLine();
       }
    }
