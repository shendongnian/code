    private void load_plugin(string pluginadd)
    {
        var loadplugin = Assembly.LoadFile(pluginadd);
        Type t = loadplugin.GetType("pluginTest.plugin");
        var guimethod = t.GetMethod("GetControl");
        if (guimethod == null)
        {
            MessageBox.Show("Can't Load GUI!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        var o = Activator.CreateInstance(t);
        var result = guimethod.Invoke(o, null);
        plug_ui.Controls.Add((UserControl)result);
        app_api newapi = new app_api();
        newapi.SetData = SetDataX;
        newapi.GetData = GetDataX;
        var apimethod = t.GetMethod("Load");
        if (apimethod == null)
        {
            MessageBox.Show("Can't Generate API!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //var o2 = Activator.CreateInstance(t); <-- DONT DO THIS
        var result2 = apimethod.Invoke(o, new object[] { newapi });
    }
