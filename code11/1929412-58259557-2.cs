      public bool Check(string s)
            {
                if ( s == null ) return false;
                if ( s.Length != 8 ) return false;
                if ( !s.Any(ch => char.IsDigit(ch))) return false;
                if ( !s.ToCharArray().where(ch => char.IsUpper(ch)).Length != 1) return false;
    
                return true;
            }
