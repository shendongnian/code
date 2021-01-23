    using System;
    using System.CodeDom.Compiler;
    using Microsoft.JScript;
    
    class JS
    {
        private delegate object EvalDelegate(String expr);
        private static EvalDelegate moEvalDelegate = null;
    
        public static object Eval(string expr)
        {
            return moEvalDelegate(expr);
        }
    
        public static T Eval<T>(string expr)
        {
            return (T)Eval(expr);
        }
    
        public static void Prepare()
        {
        }
    
        static JS()
        {
            const string csJScriptSource = @"package _{ class _{ static function __(e) : Object { return eval(e); }}}";
            var loParameters = new CompilerParameters() { GenerateInMemory = true };
            var loMethod = (new JScriptCodeProvider()).CompileAssemblyFromSource(loParameters, csJScriptSource).CompiledAssembly.GetType("_._").GetMethod("__");
            moEvalDelegate = (EvalDelegate)Delegate.CreateDelegate(typeof(EvalDelegate), loMethod);
        }
    }
