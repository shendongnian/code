            int MAX_PATH = 255;
            var actionIndex = pin ? 5386 : 5387; // 5386 is the DLL index for"Pin to Tas&kbar", ref. http://www.win7dll.info/shell32_dll.html
            StringBuilder szPinToStartLocalized = new StringBuilder(MAX_PATH);
            IntPtr hShell32 = LoadLibrary("Shell32.dll");
            LoadString(hShell32, (uint)actionIndex, szPinToStartLocalized, MAX_PATH);
            string localizedVerb = szPinToStartLocalized.ToString();
            // create the shell application object
            dynamic shellApplication = Activator.CreateInstance(Type.GetTypeFromProgID("Shell.Application"));
            string path = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);
            dynamic directory = shellApplication.NameSpace(path);
            dynamic link = directory.ParseName(fileName);
            dynamic verbs = link.Verbs();
            for (int i = 0; i < verbs.Count(); i++)
            {
                dynamic verb = verbs.Item(i);
                if ((pin && verb.Name.Equals(localizedVerb)) || (!pin && verb.Name.Equals(localizedVerb)))
                {
                    verb.DoIt();
                    break;
                }
            }
