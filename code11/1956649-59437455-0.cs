     public static dynamic ComObjectGet () {
        const string progID = "ComExampleNamespace.ComImplementation";
        Type foo = Type.GetTypeFromProgID (progID);
    
        //var bar = Guid.Parse ("99929AA7-0334-4B2D-AC74-5E282A12D06C");
        //Type foo = Type.GetTypeFromCLSID (bar);
        
        dynamic COMobject = Activator.CreateInstance (foo);
        return COMobject;
      }
