    public class Overloader
    {
      public string Str {get;private set;}
      public Overloader (string str) {Str = str;}
      public bool Equals( Overloader str )
      {
        return this.Str.Equals( str );
      }
    }
    public class Overrider
    {
      public string Str {get;private set;}
      public Overrider (string str) {Str = str;}
      public override bool Equals( object obj )
      {
        if ( obj is Overrider )
        {
          return this.Str.Equals( (obj as Overrider).Str );
        }
        return base.Equals( obj );
      }
    }
