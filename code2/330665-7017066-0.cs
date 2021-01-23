    public class MyChar
    {
        private static char _wild = '0';
        
        private char _theChar;
        
        public MyChar(char c)
        {
            _theChar = c;
        }
        
        public MyChar ()
            :this (_wild)
        {}
        
        private bool IsWildCard ()
        {
            return _theChar.Equals (_wild);
        }        
        
        public static implicit operator char (MyChar c)
        {
            return c._theChar;
        }
        
        public static implicit operator MyChar (char c)
        {
            return new MyChar (c);
        }
        
        
        public override bool Equals (object obj)
        {
            if (!(obj is MyChar))
            {
                return base.Equals (obj);
            }
            else
            {
                if (IsWildCard ())
                {
                    return true;
                }
                else
                {
                    MyChar theChar = (MyChar) obj;
                    return theChar.IsWildCard () || base.Equals ((char) theChar);
                }
            }
        }
        
        public override int GetHashCode ()
        {
            return _theChar.GetHashCode ();
        }
    }
