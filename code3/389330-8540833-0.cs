    public class SubscriptionExtension : UnityContainerExtension
    {
      protected override void Initialize()
      {
        var strategy = new SubscriptionStrategy();
        Context.Strategies.Add(strategy, UnityBuildStage.PostInitialization);
      }
    }
    public class SubscriptionStrategy : BuilderStrategy
    {
      public override void PostBuildUp(IBuilderContext context)
      {
        if (context.Existing != null)
        {
          LoaderDriver ld = context.Existing as LoaderDriver;
          if(ld != null)
          {
            ld.LoadComplete += Program_LoadComplete;
          }
        }
      }
    }
