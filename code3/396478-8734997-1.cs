    foreach (Type t in asm.GetTypes())
    {
        if (typeof(ISettings).IsAssignableFrom(t)) 
        {
            //Found a Class that is usable
            ISettings loadedSetting = Activator.CreateInstance(t);
            Console.WriteLine(loadedSetting.Description);
        }  
    }
