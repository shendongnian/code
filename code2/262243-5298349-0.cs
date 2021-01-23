    static void Main()
        {
            var processStartInfo = new ProcessStartInfo("msdeploy.exe")
                {
                    RedirectStandardOutput = true,
                    Arguments = "-verb:getDependencies -source:webServer -xml",
                    UseShellExecute = false
                };
            var process = new Process {StartInfo = processStartInfo};
            process.Start();
            var outputString = process.StandardOutput.ReadToEnd();
            
            var dependencies =  ParseGetDependenciesOutput(outputString);
            
        }
        public static GetDependenciesOutput ParseGetDependenciesOutput(string outputString)
        {
            var doc = XDocument.Parse(outputString);
            var dependencyInfo = doc.Descendants().Single(x => x.Name == "dependencyInfo");
            var result = new GetDependenciesOutput
                {
                    Dependencies = dependencyInfo.Descendants().Where(descendant => descendant.Name == "dependency"),
                    AppPoolsInUse = dependencyInfo.Descendants().Where(descendant => descendant.Name == "apppoolInUse"),
                    NativeModules = dependencyInfo.Descendants().Where(descendant => descendant.Name == "nativeModule"),
                    ManagedTypes = dependencyInfo.Descendants().Where(descendant => descendant.Name == "managedType")
                };
            return result;
        }
        public class GetDependenciesOutput
        {
            public IEnumerable<XElement> Dependencies;
            public IEnumerable<XElement> AppPoolsInUse;
            public IEnumerable<XElement> NativeModules;
            public IEnumerable<XElement> ManagedTypes;
        }
