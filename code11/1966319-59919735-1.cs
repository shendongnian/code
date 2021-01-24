        const string location = @"..\..\..\..\Dependency\bin\Debug\netcoreapp3.1\";
        static void Main(string[] args)
        {
            var domain = AppDomain.CurrentDomain;
            domain.AssemblyResolve += Domain_AssemblyResolve;
            object obj = domain.CreateInstanceAndUnwrap(
               "Dependency, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
               "Dependency.DependentClass");
            Console.WriteLine(obj.ToString());     
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
**EDIT:** After the downvote, I looked up the above solution again and although it works it seems more likely a `. net Framework` kind of a solution rather than a `.net Core`
So a more `. net Core` like solution is  to use a [`AssemblyLoadContext`](https://docs.microsoft.com/en-us/dotnet/standard/assembly/unloadability).
>Define a custom assembly load context.
public class CustomLoadContext : AssemblyLoadContext
    {
        private readonly AssemblyDependencyResolver resolver;
        public CustomLoadContext(string mainAssemblyToLoadPath) : base(isCollectible: true)
        {
            resolver = new AssemblyDependencyResolver(mainAssemblyToLoadPath);
        }
        protected override Assembly Load(AssemblyName name)
        {
            Console.WriteLine("Resolving : {0}",name.FullName);
            var assemblyPath = resolver.ResolveAssemblyToPath(name);
            if (assemblyPath != null)
            {
                return Assembly.Load(File.ReadAllBytes(assemblyPath));
            }
            return Assembly.Load(name);
        }
    }
> Load your assembly and let the custom loader context to  load it's dependencies.
        const string location = @"..\..\..\..\Dependency\bin\Debug\netcoreapp3.1\";
        static void Main(string[] args)
        {
            var fullPath = Path.GetFullPath(location + "Dependency.dll");
            var clx = new CustomLoadContext(fullPath); // initialize custom context
            var asm = clx.LoadFromStream(new MemoryStream(File.ReadAllBytes(fullPath))); // load your desired assembly
            var ins = asm.CreateInstance("Dependency.DependentClass");  
            Console.WriteLine(ins.ToString());
       
        }
