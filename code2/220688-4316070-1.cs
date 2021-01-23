    class Client : SubjectAccessor { 
      static void Main() {
        Console.WriteLine("Proxy Pattern\n");
        
        ISubject subject = new Proxy();
        Console.WriteLine(subject.Request());
        Console.WriteLine(subject.Request());
        ProtectionProxy subject = new ProtectionProxy();
        Console.WriteLine(subject.Request());
