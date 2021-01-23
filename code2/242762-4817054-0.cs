        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            this.Loaded += new Accordion_Loaded;
        }
        void Accordion_Loaded(object sender, RoutedEventArgs e)
        {
            var presenter = (ItemsPresenter)this.Template.FindName("PART_Presenter", this);
            var stackPanel = (StackPanel)this.ItemsPanel.FindName("PART_StackPanel", presenter);
        }
