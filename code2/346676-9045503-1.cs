    public class ExRibbon : Ribbon
    {
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            IsMinimizedProperty.OverrideMetadata(typeof(ExRibbon),
                    new FrameworkPropertyMetadata(false, (o, e) => { }, (o, e) => false));
    
            Type ownerType = typeof(ExRibbon);
            CommandManager.RegisterClassCommandBinding(ownerType,
                new CommandBinding(RibbonCommands.MinimizeRibbonCommand, null, MinimizeRibbonCanExecute));
        }
    
        private static void MinimizeRibbonCanExecute(object sender, CanExecuteRoutedEventArgs args)
        {
            args.CanExecute = false;
            args.Handled = true;
        }
    }
