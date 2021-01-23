    using System.Runtime.InteropServices;
    public class TestEnv
    {
        [DllImport( "msvcrt.dll" )]
        public static extern int _putenv_s( string e, string v );
        public TestEnv()
        {
            _putenv_s( "ENV_VAR", "VALUE" );
        }
    }
