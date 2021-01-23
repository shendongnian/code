    object wellKnownObject =
      Activator.GetObject(iTheInterface, "tcp://localhost:9090/Remotable.rem");
    var objType = wellKnownObject.GetType();
    var methods = objType.GetMethods();
    var interfaces = objType.GetInterfaces();
