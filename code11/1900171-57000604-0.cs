    public class MyExtensionProvider : ExtensionIdProvider<MyExtension>
    {
        public override MyExtension CreateExtension(ExtendedActorSystem system) =>
            new MyExtension(system);
    }
    public class MyExtension : IExtension
    {
        public MyExtension(ExtendedActorSystem system) { }
    }
