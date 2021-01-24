using System;
using System.Xml;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NUnit.Engine;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var testAssemblyPath = @"C:\src\qata\src\tests\external\SomethingProject.Tests\bin\Debug\net461\SomethingProject.Tests.dll";
            var package = new TestPackage(testAssemblyPath);
            var testEngine = new TestEngine();
            var runner = testEngine.GetRunner(package);
            var nUnitXml = runner.Explore(TestFilter.Empty);
            var session = new DiaSession(testAssemblyPath);
            foreach (XmlNode testNode in nUnitXml.SelectNodes("//test-case"))
            {
                var testName = testNode.Attributes["fullname"]?.Value;
                var className = testNode.Attributes["classname"]?.Value;
                var methodName = testNode.Attributes["methodname"]?.Value;
                var navigationData = session.GetNavigationData(className, methodName);
                Console.WriteLine($"{testName} - {navigationData.FileName} - {navigationData.MinLineNumber}.");
            }
        }
    }
}
