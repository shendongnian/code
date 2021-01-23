      Base b = new Base();
      Derived d = new Derived();
      Base b2 = d;
    
      Console.WriteLine(b.VirtualMethod());
      Console.WriteLine(d.VirtualMethod());
      Console.WriteLine(b2.VirtualMethod());
    
      Console.WriteLine(b.NotVirtual());
      Console.WriteLine(d.NotVirtual());
      Console.WriteLine(b2.NotVirtual());
