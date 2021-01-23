	using Microsoft.Build.BuildEngine;
	using Microsoft.Build.Framework;
	using Microsoft.Build.Utilities;public class SolutionBuilder
	{
		BasicFileLogger b;
		public SolutionBuilder() { }
		[STAThread]
		public string Compile(string solution_name,string logfile)
		{
			b = new BasicFileLogger();
			b.Parameters = logfile;
			b.register();
			Microsoft.Build.BuildEngine.Engine.GlobalEngine.BuildEnabled = true;
			Project p = new Project (Microsoft.Build.BuildEngine.Engine.GlobalEngine);
			p.BuildEnabled = true;
			p.Load(solution_name);
			p.Build();
			string output = b.getLogoutput();
			output += “nt” + b.Warningcount + ” Warnings. “;
			output += “nt” + b.Errorcount + ” Errors. “;
			b.Shutdown();
			return output;
		}
	}
	//The above class is used and compilation is initiated by the following code,
	static void Main(string[] args)
	{
		SolutionBuilder builder = new SolutionBuilder();string output = builder.Compile(@”G:CodesTestingTesting2web1.sln”, @”G:CodesTestingTesting2build_log.txt”);
		Console.WriteLine(output);
		Console.ReadKey();
	}
