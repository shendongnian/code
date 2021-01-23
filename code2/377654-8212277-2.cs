using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Net;
namespace Cobra
{
    public static class Program
    {
        public static int A { get; set; }//Getter/Setter is important else "GetProperties" will not be able to detect it
        public static int B { get; set; }
        
        static void Main(string[] args)
        {
            HttpHandler obj = new HttpHandler();
            obj.ProcessRequest(typeof(Program));
        }
    }
}
