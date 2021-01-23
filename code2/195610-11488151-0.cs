    if(!Exists(new PhysicalResource())) //Check to see if a physical resource exists.
    {
        PhysicalResource.Create(); //Extract embedded resource to disk.
    }
    
    PhysicalResource pr = new PhysicalResource(); //Create physical resource instance.
    
    pr.Read(); //Read from physical resource.
    
    pr.Write(); //Write to physical resource.
