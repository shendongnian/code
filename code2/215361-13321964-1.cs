    var session = Session.Create();
    var engine = new ScriptEngine();
    engine.Execute("using System;", session);
    engine.Execute("double Sin(double d) { return Math.Sin(d); }", session);
    engine.Execute("MessageBox.Show(Sin(1.0));", session);
