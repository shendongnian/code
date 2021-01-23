    <object id="bigCartHost" type="Spring.ServiceModel.Activation.ServiceHostFactoryObject, Spring.Services">
      <property name="TargetName" value="bigCart" />
    </object>
    ContextRegistry.GetContext(); // Force Spring to load configuration
    Console.Out.WriteLine("Server listening...");
    Console.Out.WriteLine("--- Press <return> to quit ---");
    Console.ReadLine();
