    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    namespace AltToSwitch
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myReportType = "A";
                var model = "myModel";
                var language = "myLanguage";
    
                var reportGenerators = new List<BaseReportGenerator>();
                
                //use assembly scanning to get all report generator implementations
                foreach (Type type in
                    Assembly.GetAssembly(typeof(BaseReportGenerator)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseReportGenerator))))
                {
                    reportGenerators.Add((BaseReportGenerator)Activator.CreateInstance(type));
                }
    
                var reportGenerator = reportGenerators.SingleOrDefault(x => x.ReportName == myReportType);
                Console.WriteLine(reportGenerator.GenerateReport(model, language));
            }
        }
    
        public abstract class BaseReportGenerator
        {
            public abstract string ReportName
            {
                get;
            }
            public abstract string GenerateReport(string model, string language);
         
            //common report functionality could go here
        }
        public class TheAReportGenerator : BaseReportGenerator
        {
            public override string ReportName => "A";
    
            public override string GenerateReport(string model, string language)
            {
                return "The A report";
            }
        }
    }
