    string file = "data.bin";
    using (var ctx = new DataContext())
    {
    	BinaryFormatter bf = new BinaryFormatter();
    	bf.Binder = new MyBinder();
    
    	Entity e;
    	using (var s = File.OpenRead(file))
    		e = (Entity)bf.Deserialize(s);
    
    	ctx.Entities.Add(e);
    	ctx.SaveChanges();
    
    	File.Move(file, Path.Combine(archiveFolder, Path.GetFileName(file)));
    }
    class MyBinder : SerializationBinder
    {
    	Dictionary<string, Type> types;
    
    	public MyBinder()
    	{
    		types = typeof(Entity).Assembly.GetTypes().Where(t => t.Namespace == "Foo.Model").ToDictionary(t => t.Name, t => t);
    	}
    
    	public override Type BindToType(string assemblyName, string typeName)
    	{
    		if (assemblyName.Contains("EntityFrameworkDynamicProxies-Foo"))
    		{
    			var type = typeName.Split('.').Last().Split('_').First();
    			return types[type];
    		}
    
    		var returnType = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
    		return returnType;
    	}
    }
