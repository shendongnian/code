    using System;
    using Microsoft.Office.Interop.Outlook;
    class Program
    {
        static void Main(string[] args)
        {
            var outlookType = Type.GetTypeFromProgID("Outlook.Application");
            if (outlookType == null)
            {
                Console.WriteLine("Not installed.");
            }
            else
            {
                var app = Activator.CreateInstance(outlookType) as Application;
                Console.WriteLine(app.Name);
            }
        }
    }
