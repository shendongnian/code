    [TestFixture]
    public class MarshalAsTest
    {
        [Test]
        public void TestMarshalAs_SetLogFileName( )
        {
            SomeClass someClass = new SomeClass( );
            string logFile = "LogFileName.log";
            someClass.SetLogFile(logFile);
            Assert.AreEqual(logFile, someClass.GetLogFile( ));            
        }
    }
    public class SomeClass
    {
        EVENT_TRACE_PROPERTIES props;
        public void SetLogFile([MarshalAs(UnmanagedType.LPWStr)]String msg)
        {
            props.LogFileName = msg;
        }
        [return: MarshalAs(UnmanagedType.LPWStr)]
        public string GetLogFile( )
        {
            return props.LogFileName;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct EVENT_TRACE_PROPERTIES
        {
            internal WNODE_HEADER WNode;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            internal string LoggerName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            internal string LogFileName;
        }
    }
