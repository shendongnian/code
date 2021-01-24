powershell
PS> Add-Type -Path 'C:\Users\UserName\.vscode\extensions\ms-vscode.csharp-1.21.11\.omnisharp\1.34.11\OmniSharp.Shared.dll'
It will produce no output if it succeeds.  Then you just need to instantiate a `FormattingOptions` instance, of which the property names and default values will be displayed to the console...
powershell
PS> New-Object -TypeName 'OmniSharp.Options.FormattingOptions'
OrganizeImports                                      : False
EnableEditorConfigSupport                            : False
NewLine                                              :
UseTabs                                              : False
TabSize                                              : 4
[snip]
You can even have it create the corresponding JSON for you...
powershell
PS> [PSCustomObject] @{ FormattingOptions = New-Object -TypeName 'OmniSharp.Options.FormattingOptions' } | ConvertTo-Json
{
  "FormattingOptions": {
    "OrganizeImports": false,
    "EnableEditorConfigSupport": false,
    "NewLine": "\n",
    "UseTabs": false,
    "TabSize": 4,
    [snip]
  }
}
...or write it directly to a default `omnisharp.json` file in the current directory...
powershell
PS> [PSCustomObject] @{ FormattingOptions = New-Object -TypeName 'OmniSharp.Options.FormattingOptions' } | ConvertTo-Json | Set-Content -Path 'omnisharp.json'
If PowerShell isn't feasible you could always create and reflect over the properties of a `FormattingOptions` instance in a little program like this...
c#
using System;
using System.Linq;
using System.Reflection;
namespace SO60131765
{
	class Program
	{
		const string FormattingOptionsQualifiedTypeName = "OmniSharp.Options.FormattingOptions";
		static int Main(string[] args)
		{
			try
			{
				if (args == null || !args.Any() || string.IsNullOrEmpty(args[0]))
					throw new Exception($"The path to the assembly containing the {FormattingOptionsQualifiedTypeName} is required.");
				else
				{
					object formattingOptions = CreateFormattingOptionsFromAssembly(args[0]);
					WriteHeader();
					WriteProperties(formattingOptions);
					return 0;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine($"ERROR: {ex.Message}");
				return 1;
			}
		}
		static object CreateFormattingOptionsFromAssembly(string assemblyPath)
		{
			Assembly assembly;
			try
			{
				assembly = Assembly.LoadFrom(assemblyPath);
			}
			catch (Exception ex)
			{
				throw new Exception($"Assembly load failed with message \"{ex.Message}\".", ex);
			}
			object formattingOptions;
			try
			{
				formattingOptions = assembly.CreateInstance(FormattingOptionsQualifiedTypeName);
			}
			catch (Exception ex)
			{
				throw new Exception($"Instantiating type {FormattingOptionsQualifiedTypeName} failed with message \"{ex.Message}\".");
			}
			if (formattingOptions == null)
				throw new Exception($"A public type {FormattingOptionsQualifiedTypeName} was not found in the specified assembly.");
			return formattingOptions;
		}
		static void WriteHeader()
		{
			string headerText = $"Public instance properties of type {FormattingOptionsQualifiedTypeName}";
			Console.WriteLine(headerText);
			Console.WriteLine(new string('=', headerText.Length));
		}
		static void WriteProperties(object formattingOptions)
		{
			PropertyInfo[] properties = formattingOptions.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public);
			int longestPropertyNameLength = properties.Max(property => property.Name.Length);
			string format = $"{{0,{longestPropertyNameLength}}}: {{1}}";
			foreach (PropertyInfo property in properties)
			{
				object propertyValue = property.GetValue(formattingOptions);
				string propertyValueText = propertyValue == null
					? "<null>"
					: propertyValue is string
					? $"\"{propertyValue}\""
					: propertyValue.ToString();
				Console.WriteLine(format, property.Name, propertyValueText);
			}
		}
	}
}
...and then execute it with the path to the `OmniSharp.Shared.dll` assembly...
> SO60131765.exe "C:\Users\UserName\.vscode\extensions\ms-vscode.csharp-1.21.11\.omnisharp\1.34.11\OmniSharp.Shared.dll"
Public instance properties of type OmniSharp.Options.FormattingOptions
======================================================================
                                     OrganizeImports: False
                           EnableEditorConfigSupport: False
                                             NewLine: "
"
                                             UseTabs: False
                                             TabSize: 4
                                               [snip]
The above technique will likely work for other editors that make use of an [OmniSharp-based extension](http://www.omnisharp.net/#integrations); it's just a matter of finding where `OmniSharp.Shared.dll` is stored.  Note that I am **not** providing the full text of a default `omnisharp.json` so this doesn't become another out-of-date source for copy-and-paste configuration.  The idea is to dynamically query the values for _your_ installed version of OmniSharp.
