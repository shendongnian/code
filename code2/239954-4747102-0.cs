    List<business.clspluginsprp> objprp = new List<business.clspluginsprp>();
    business.clsplugins obj = new business.clsplugins();
    for (Int32 i = 0; i < k.Length; i++)
    {
        
        Int32 z = Convert.ToInt32(k.GetValue(i));
        objprp.Add(obj.fnd_plugins(z));
        
    }
    GridView2.DataSource = objprp;
    GridView2.DataBind();
