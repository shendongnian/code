    [KnownType( typeof( C2 ) )]
    [KnownType( typeof( C3 ) )]
    public class C1 {public string P1 {get;set;}}
    public class C2 :C1 {public string P2 {get;set;}}
    public class C3 :C1 {public string P3 {get;set;}}
    
    class Program
    {
      static void Main(string[] args)
      {
        var c1 = new C1{ P1="c1"};
        var c2 = new C2{ P1="c1", P2="c2"};
        var c3 = new C3{ P1="c1", P3="c3"};
        var s = new DataContractSerializer( typeof( C1 ) );
        Test( c1, s );
        Test( c2, s );
        Test( c3, s );
      }
      static void Test( C1 objectToSerialize, DataContractSerializer serializer )
      {
        using ( var stream = new MemoryStream() )
        {
          serializer.WriteObject( stream, objectToSerialize );
          stream.WriteTo( Console.OpenStandardOutput() );
          stream.Position = 0;
          var deserialized = serializer.ReadObject( stream );
          Console.WriteLine( Environment.NewLine + "Deserialized Type: " + deserialized.GetType().FullName );              
        }
      }
    }
