    public class LibWrap
    {
        /*
        class PINVOKELIB_API CTestClass 
        {
            public:
                CTestClass( void );
                int DoSomething( int i );
            private:
                int m_member;
        }; 
        */
        [ DllImport( "..\\LIB\\PinvokeLib.dll", 
        EntryPoint="?DoSomething@CTestClass@@QAEHH@Z", 
        CallingConvention=CallingConvention.ThisCall )]
        public static extern int TestThisCalling( IntPtr ths, int i ); 
        // CTestClass* CreateTestClass();
        [DllImport( "..\\LIB\\PinvokeLib.dll" )]
        public static extern IntPtr CreateTestClass(); 
        // void DeleteTestClass( CTestClass* instance )
        [ DllImport( "..\\LIB\\PinvokeLib.dll" )]
        public static extern void DeleteTestClass( IntPtr instance ); 
    }
