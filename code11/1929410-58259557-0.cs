      public bool Check(string s)
            {
                if ( s == null ) return false;
                if ( s.length != 8 ) return false;
                if ( !s.Any(ch => char.IsDigit(ch))) return false;
                if ( !s.Any(ch => char.IsUpper(ch))) return false;
    
                return true;
            }
