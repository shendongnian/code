    //csc sample.cs -r:Microsoft.JScript.dll
    using System;
    using System.CodeDom.Compiler;
    using Microsoft.JScript;
    
    class Sample {
        static public void Main(){
            string[] source = new string[] {
    @"import System;
    class JsProgram {
        function Print(mes){
            Console.WriteLine(mes);
        }
        function Hello(world){
            Print(world);
        }
        function proc(){
            var world = ""World"";
            var bool = true;
            if(bool == true){
                Print(""True is True"");
            }
            else{
                Print(""False is True"");
            }
            Hello(world);
        }
    }"
            };
            var compiler = new JScriptCodeProvider();
            var opt      = new CompilerParameters();
            opt.ReferencedAssemblies.Add("System.dll");
            opt.GenerateExecutable = false;
            opt.GenerateInMemory = true;
            var result = compiler.CompileAssemblyFromSource(opt, source);
            if(result.Errors.Count > 0){
                Console.WriteLine("Compile Error");
                return;
            }
            var js = result.CompiledAssembly;
            dynamic jsProg = js.CreateInstance("JsProgram");
            jsProg.proc();
    /*
    True is True
    World
    */
        }
    }
