        Assembly a = cr.CompiledAssembly;
        try {
            Type type = a.GetType("dynamic_scripting.DynScripting");
            int result = (int) type.GetMethod("executeScript").Invoke(
                null, new object[] {"CSharpScript" });
        }
        catch(Exception ex) {
            MessageBox.Show(ex.Message);
        }
