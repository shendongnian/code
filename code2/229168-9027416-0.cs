    static void Main(string[] args)
        {
            string unknownAppPath = @"path-to-your-dll";
            Console.WriteLine("Testing");
            try
            {
                AppDomainSetup setup = new AppDomainSetup();
                setup.AppDomainInitializer = new AppDomainInitializer(TestAppDomain);
                setup.AppDomainInitializerArguments = new string[] { unknownAppPath };
                AppDomain testDomain = AppDomain.CreateDomain("test", AppDomain.CurrentDomain.Evidence, setup);
                AppDomain.Unload(testDomain);
                File.Delete(unknownAppPath);
            }
            catch (Exception x)
            {
                Console.WriteLine(x.Message);
            }
            Console.ReadKey(); 
        }
        public static void TestAppDomain(string[] args)
        {
            string unknownAppPath = args[0];
            AppDomain.CurrentDomain.DoCallBack(delegate()
            {
                //check that the new assembly is signed with the same public key
                Assembly unknownAsm = AppDomain.CurrentDomain.Load(AssemblyName.GetAssemblyName(unknownAppPath));
                //get the new assembly public key
                byte[] unknownKeyBytes = unknownAsm.GetName().GetPublicKey();
                string unknownKeyStr = BitConverter.ToString(unknownKeyBytes);
                //get the current public key
                Assembly asm = Assembly.GetExecutingAssembly();
                AssemblyName aname = asm.GetName();
                byte[] pubKey = aname.GetPublicKey();
                string hexKeyStr = BitConverter.ToString(pubKey);
                if (hexKeyStr == unknownKeyStr)
                {
                    //keys match so execute a method
                    Type classType = unknownAsm.GetType("namespace.classname");
                    classType.InvokeMember("method-you-want-to-invoke", BindingFlags.InvokeMethod, null, null, null);
                }
            });
        }
