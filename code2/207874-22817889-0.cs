    public class FolderDialogBehavior : Behavior<Button>
    {
        public string SetterName { get; set; }
 
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.Click += OnClick;
        }
        
        protected override void OnDetaching()
        {
            AssociatedObject.Click -= OnClick;
        }
 
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var dialog = new FolderBrowserDialog();
            var result = dialog.ShowDialog();
            if (result == DialogResult.OK && AssociatedObject.DataContext != null)
            {
                var propertyInfo = AssociatedObject.DataContext.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(p => p.CanRead && p.CanWrite)
                .Where(p => p.Name.Equals(SetterName))
                .First();
 
                propertyInfo.SetValue(AssociatedObject.DataContext, dialog.SelectedPath, null);
            }
        }
    }
