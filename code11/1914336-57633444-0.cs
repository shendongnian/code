//Setting required options.
RepackOptions opt = new RepackOptions();
opt.OutputFile = "example_packed.exe";
opt.SearchDirectories = new string[] { AppDomain.CurrentDomain.BaseDirectory, Environment.CurrentDirectory };
//Setting input assemblies.
string[] files = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll");
opt.InputAssemblies = new string[] { "example.exe", entryasm.Location }.Concat(files).ToArray();
//Merging.
ILRepack pack = new ILRepack(opt);
pack.Repack();
