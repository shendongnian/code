    var editorServiceContext = typeof(ControlDesigner).Assembly.GetTypes()
        .Where(x => x.Name == "EditorServiceContext").FirstOrDefault();
    var editValue = editorServiceContext.GetMethod("EditValue",
        System.Reflection.BindingFlags.Static |
        System.Reflection.BindingFlags.Public);
    editValue.Invoke(null, new object[] { this, this.Component, "The Property Name" });
