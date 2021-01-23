    [Export(typeof(IModule))]
    public class LayoutsModule : AModule
    {
        private static LayoutsVM viewModel;
        /// <summary>
        /// Gets reporting add-in main view model
        /// </summary>
        public static LayoutsVM ViewModel
        {
            get
            {
                if (viewModel == null)
                {
                    viewModel = Context
                                    .Current
                                    .LayoutManager
                                    .ModulesVM
                                    .OfType<LayoutsVM>()
                                    .FirstOrDefault();
                }
                return viewModel;
            }
        }
        /// <summary>
        /// Initialize module
        /// </summary>
        public override void Initialize()
        {
            Context
                .Current
                .EventAggregator
                .GetEvent<MenuInitializing>()
                .Subscribe(this.InitializeMenu);
            base.Initialize();
        }
    }
