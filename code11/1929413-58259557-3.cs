      using System.Linq;	
      public bool Check(string s)
            {
                if ( s == null ) return false;
                if ( s.Length != 8 ) return false;
                if ( !s.ToCharArray().Any(ch => char.IsDigit(ch))) return false;
                if ( !(s.ToCharArray().Where(ch => char.IsUpper(ch)).Count() != 1)) return false;
    
                return true;
            }
