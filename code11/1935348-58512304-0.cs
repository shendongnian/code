cs
using System;
using System.Diagnostics;
namespace TestApp
{
  class Program
  {
    static void Main(string[] args)
    {
      Console.WriteLine(Process.GetCurrentProcess().ProcessName);
    }
  }
}
When running `dotnet run` it shows dotnet. I built a standalone version `dotnet publish -c Release -r win10-x64` and it shows TestApp.
I'm not sure how reliable this is though.
