    var obj =  new GameObject();
    foreach (var cp in cpList)
    {
        obj.AddComponent(Assembly.GetExecutingAssembly().GetType(cp));
        // maybe Type.GetType(cp) is enough as well
    }
