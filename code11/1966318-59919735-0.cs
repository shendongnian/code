        const string location = @"..\..\..\..\Dependency\bin\Debug\netcoreapp3.1\";
        static void Main(string[] args)
        {
            var domain = AppDomain.CurrentDomain;
            domain.AssemblyResolve += Domain_AssemblyResolve;
            object obj = domain.CreateInstanceAndUnwrap(
               "Dependency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
               "Dependency.DependentClass");
            Console.WriteLine(obj.ToString());
            Console.ReadLine();
        }
        private static Assembly Domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            var dll = $"{args.Name.Split(",")[0]}.dll";
            var path = Path.Combine(location, dll);
            var asm = Assembly.Load(File.ReadAllBytes(path));
            return asm;
        }
A side note: You need to provide full name for type else it will throw error. Like: `"Dependency.DependentClass"` 
Dependency assembly has 2 dependencies one is `Newtonsoft.Json` NuGet package, the other one is another project. `Bar` class resides in another project.
 public class DependentClass
    {
        public int MyProperty { get; set; }
        public string AnotherProperty { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(new Bar());
        }
    }
