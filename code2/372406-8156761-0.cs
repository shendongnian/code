    using System.Data;
    using System.Data.Common;
    using System.Configuration;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Microsoft.Data.Schema.UnitTesting;
    using System.Windows.Input;
    using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
    using Mouse = Microsoft.VisualStudio.TestTools.UITesting.Mouse;
    using MouseButtons = System.Windows.Forms.MouseButtons;
    namespace CSIS_TEST
    {
        [TestClass()]
        public class DatabaseSetup
        {
            static private UIMap uIMap = new UIMap();
            static int count = 0;
    
            [AssemblyInitialize()]
            public static void InitializeAssembly(TestContext ctx)
            {
                DatabaseTestClass.TestService.DeployDatabaseProject();
                DatabaseTestClass.TestService.GenerateData();
    
                if(count < 1)
                    uIMap.OpenWindow();
                count++;
            }
    
            [AssemblyCleanup()]
            public static void InitializeAssembly()
            {            
                uIMap.CloseWindow();
            }
        }
    }
