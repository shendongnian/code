`
class OutputFile : IDisposable
{
   Excel.Application ExcelApp { get; set; } 
   public OutputFile() 
   { 
      ExcelApp = new Excel.Application(); 
   }
   public void Dispose() 
   { 
      ExcelApp.Close(); 
      ExcelApp.Quit(); 
   }
} 
`
Usage:
`csharp
using(var outputFile = new OutputFile())
{
   // do stuff with output file 
} 
`
