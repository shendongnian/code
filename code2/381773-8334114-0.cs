    public class DateTimeColumn : GridViewColumn
    {
        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
            if (Equals(e.PropertyName, "DisplayMemberBinding") && DisplayMemberBinding != null)
            {
                DisplayMemberBinding.StringFormat = "{0:yyyy.MM.dd}";
            }
        }
    }
XAML code...
    <local:DateTimeColumn DisplayMemberBinding="{Binding Date1}" />
