    public class RegExpTester
        {
            private readonly Regex engine;
    
            protected RegExpTester( string expression )
            
                if ( string.IsNullOrEmpty( expression ) )
                {
                    throw new ArgumentException( "expression null or empty" );
                }
                engine = new Regex( expression );
            }
    
            public bool test( string strToBeTested )
            {
                return engine.IsMatch( strToBeTested );
            }
        }
    
        public sealed class emailTester : RegExpTester
        {
            static emailTester instance = new emailTester();
    
            emailTester() : base( "some mail expression" ) { }
    
            public static emailTester Instance
            {
                get
                {
                    return instance;
                }
            }
        }
