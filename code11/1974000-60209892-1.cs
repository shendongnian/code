    public void ChooseRightInstance(VersionAssembly240 obj1, VersionAssembly250 obj2, VersionAssembly260 obj3, string version)
    {
    	IVersionAssembly obj;
        if (version == "v24")
        {
            obj = obj1;
        }
        else if (version == "v25")
        {
            obj = obj2;
        }
        else
        {
            obj = obj3;
        }
    
        obj.example();
    }
