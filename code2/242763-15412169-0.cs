        [TemplatePartAttribute(Name = "PART_StackPanel", Type = typeof(StackPanel))]
        [TemplatePartAttribute(Name = "PART_Presenter", Type = typeof(ItemsPresenter))]
        public class CustomItemsControl : ItemsControl
        {
            public override void OnApplyTemplate()
            {
                base.OnApplyTemplate();
                var presenter = (ItemsPresenter)this.Template.FindName("PART_Presenter", this);
                presenter.ApplyTemplate();
                var stackPanel = (StackPanel)this.ItemsPanel.FindName("PART_StackPanel", this);
            }
        }
