    public class ApplicationContextNavigator : ApplicationContext, INavigator
    {
      private readonly IWindsorContainer container;
      private IView Current { ... }
      public ApplicationContextNavigator(IWindsorContainer container) {...}
      public void Start<TView>() where TView : IView { ... }
      public void Start<TView>(IViewInitializer initializer) where TView : IView
      {
        Current = InitializeView<TView>(initializer);
        Application.Run(this);
      }
    
      public void Navigate<TView>() where TView : IView { ... }
      public void Navigate<TView>(IViewInitializer initializer) where TView : IView
      {
        IView closing = Current;
        IView showing = InitializeView<TView>(initializer);
    
        showing.Location = closing.Location;
        showing.Show();
                
        Current = showing;
        closing.Close();
      }
    
      private IView InitializeView<TView>(IViewInitializer initializer) where TView : IView
      {
        IView view = container.Resolve<TView>();
        initializer.Initialize(view);
        return view;
      }
      protected override void OnMainFormClosed(object sender, EventArgs e)
      {
        if(sender == Current)
        {
          base.OnMainFormClosed(sender, e);
        }
      }
    }
