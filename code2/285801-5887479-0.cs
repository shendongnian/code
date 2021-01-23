    public abstract class HorribleBaseType
    {
      private Lazy<string> _connectionString;
      private Action<string> _connectionStringSetter;
      private Func<string> _connectionStringGetter;
      public HorribleBaseType(
        Func<string> connectionStringGetter, 
        Action<string> connectionStringSetter)
      {
        _connectionStringGetter = connectionStringGetter;
        _connectionStringSetter = connectionStringSetter;
        
        _connectionString = new Lazy<string>(connectionStringGetter);
      }
      public string ConnectionString
      {
        get { return _connectionString.Value; }
        set 
        { 
          _connectionStringSetter(value);
          _connectionString = new Lazy<string>(_connectionStringGetter);
        }
      }
    }
    public class HorribleType : HorribleBaseType
    {
      public HorribleType()
        : base(() => MyConfiguration.ConnectionString,
               (v) => MyConfiguration.ConnectionString = v) { }
    }
