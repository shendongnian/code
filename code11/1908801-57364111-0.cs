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
    
                var reportGenerators = new List<BaseReportGenerator>();
                foreach (Type type in
                    Assembly.GetAssembly(typeof(BaseReportGenerator)).GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(BaseReportGenerator))))
                {
                    reportGenerators.Add((BaseReportGenerator)Activator.CreateInstance(type));
                }
    
                var reportGenerator = reportGenerators.SingleOrDefault(x => x.ReportName == myReportType);
                Console.WriteLine(reportGenerator.GenerateReport());
            }
        }
    
        public abstract class BaseReportGenerator
        {
            public abstract string ReportName
            {
                get;
            }
            public abstract string GenerateReport();
         
            //common report functionality
        }
        public class TheAReportGenerator : BaseReportGenerator
        {
            public override string ReportName => "A";
    
            public override string GenerateReport()
            {
                return "The A report";
            }
        }
    }
