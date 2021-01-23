using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using EnvDTE;
using EnvDTE80;
namespace DTETesting
{
    class Program
    {
        const string ACTIVE_OBJECT = "VisualStudio.DTE.10.0";
        static void Main(string[] args)
        {
            EnvDTE80.DTE2 MyDte;
            MyDte = (EnvDTE80.DTE2)System.Runtime.InteropServices.Marshal.GetActiveObject(ACTIVE_OBJECT);
            Console.WriteLine("The Edition is "+MyDte.Edition);
            Console.ReadLine();
        }
    }
}
