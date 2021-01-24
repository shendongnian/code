cs
var decompiler = new CSharpDecompiler(assemblyFileName, new DecompilerSettings());
string code = decompiler.DecompileWholeModuleAsString();
See the [ICSharpCode.Decompiler.Console](https://github.com/icsharpcode/ILSpy/tree/master/ICSharpCode.Decompiler.Console) project for slightly more advanced usage of the decompiler API.
The part with `resolver.AddSearchDirectory(path);` in that console project may be relevant, because the decompiler needs to find the referenced assemblies.
---
The ICSharpCode.Decompiler library also has a disassembler API (which is a bit more low-level):
cs
string code;
using (var peFileStream = new FileStream(sourceFileName, FileMode.Open, FileAccess.Read))
using (var peFile = new PEFile(sourceFileName, peFileStream))
using (var writer = new StringWriter()) {
	var output = new PlainTextOutput(writer);
	ReflectionDisassembler rd = new ReflectionDisassembler(output, CancellationToken.None);
	rd.DetectControlStructure = false;
	rd.WriteAssemblyReferences(peFile.Metadata);
	if (metadata.IsAssembly)
		rd.WriteAssemblyHeader(peFile);
	output.WriteLine();
	rd.WriteModuleHeader(peFile);
	output.WriteLine();
	rd.WriteModuleContents(peFile);
	code = writer.ToString();
}
