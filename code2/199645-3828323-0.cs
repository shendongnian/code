    public class MyBookmarkedActivity : NativeActivity
    {
        protected override void CacheMetadata(NativeActivityMetadata metadata)
        {
            base.CacheMetadata(metadata);
            metadata.AddDefaultExtensionProvider<MyExtension>(() => new MyExtension());
        }
     
        protected override void Execute(NativeActivityContext context)
        {
            var extension = context.GetExtension<MyExtension>();
            extension.DoSomething();
     
        }
    }
