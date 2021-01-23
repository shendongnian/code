    System.Reflection.Assembly assemby = System.Reflection.Assembly.GetExecutingAssembly();
    System.Type[] types = assemby.GetTypes();
    var varWindows = types.ToList()
        .Where(current => current.BaseType == typeof(Window));
    MessageBox.Show(varWindows.Count().ToString());
