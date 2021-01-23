    using System;
    using Microsoft.Scripting.Hosting;
    using IronRuby;
    class ExecuteRubyExample
    {
        static void Main()
        {
            ScriptEngine engine = IronRuby.Ruby.CreateEngine();
            engine.ExecuteFile("C:/rubyscript.rb");
        }
    }
