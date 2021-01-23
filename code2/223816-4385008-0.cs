    using System;
    using Microsoft.JScript;
    using Microsoft.JScript.Vsa;
    
    namespace JustTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                object value = Eval.JScriptEvaluate("1+2-(3*5)", VsaEngine.CreateEngine());
                Console.Write(value);
                Console.ReadLine();
            }
        }
    }
