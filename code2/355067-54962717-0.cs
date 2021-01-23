    public static byte[] SerializeAssembly()
    {
      var compilerOptions = new Dictionary<string, string> { { "CompilerVersion", "v4.0" } };
      CSharpCodeProvider provider = new CSharpCodeProvider(compilerOptions);
      CompilerParameters parameters = new CompilerParameters()
      {
        GenerateExecutable = false,
        GenerateInMemory = false,
        OutputAssembly = "Examples.dll",
        IncludeDebugInformation = false,
      };
      parameters.ReferencedAssemblies.Add("System.dll");
      ICodeCompiler compiler = provider.CreateCompiler();
      CompilerResults results = compiler.CompileAssemblyFromSource(parameters, StringClassFile());
      return File.ReadAllBytes(results.CompiledAssembly.Location);
    }
    private static Assembly DeserializeAssembyl(object fromDataReader)
    {
      byte[] arr = (byte[])fromDataReader;
      return Assembly.Load(arr);
    }
  
    private string StringClassFile()
        {
          return "using System;" +
          "using System.IO;" +
          "using System.Threading;" +
          "namespace Examples" +
          "{" +
          "	public class FileCreator" +
          "	{" +
          "		private string FolderPath { get; set; }" +
          "		public FileCreator(string folderPath)" +
          "		{" +
          "			this.FolderPath = folderPath;" +
          "		}" +
          "		public void CreateFile(Guid name)" +
          "		{" +
          "			string fileName = string.Format(\"{0}.txt\", name.ToString());" +
          "			string path = Path.Combine(this.FolderPath, fileName);" +
          "			if (!File.Exists(path))" +
          "			{" +
          "				using (StreamWriter sw = File.CreateText(path))" +
          "				{" +
          "					sw.WriteLine(\"file: {0}\", fileName);" +
          "					sw.WriteLine(\"Created from thread id: {0}\", Thread.CurrentThread.ManagedThreadId);" +
          "				}" +
          "			}" +
          "			else" +
          "			{" +
          "				throw new Exception(string.Format(\"duplicated file found {0}\", fileName));" +
          "			}" +
          "		}" +
          "	}" +
          "}";
        }
