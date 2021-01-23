    public class ViewModel
    {
        public MetadataViewModel Metadata { get; } = new MetadataViewModel();
    
        public async Task ShowMessage(string msg, decimal centenary, double year)
        {
            await Task.Delay(0);
            MessageBox.Show(msg + centenary + year);
        }
    
        public class MetadataViewModel
        {
            public void ShowInfo(Window window, double windowWidth, ViewModel viewModel, object sender, MouseButtonEventArgs eventArgs)
            {
                var sb = new StringBuilder("Window width: ")
                    .AppendLine(windowWidth.ToString())
                    .Append("View model type: ").AppendLine(viewModel.GetType().Name)
                    .Append("Sender type: ").AppendLine(sender.GetType().Name)
                    .Append("Clicked button: ").AppendLine(eventArgs.ChangedButton.ToString())
                    .Append("Mouse X: ").AppendLine(eventArgs.GetPosition(window).X.ToString())
                    .Append("Mouse Y: ").AppendLine(eventArgs.GetPosition(window).Y.ToString());
                MessageBox.Show(sb.ToString());
            }
        }
    }
