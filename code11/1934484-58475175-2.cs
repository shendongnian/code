public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;
    private SelectionViewModel selectionViewModel;
    
    public SelectionViewModel SelectionViewModel
    {
        get
        {
            return this.selectionViewModel;
        }
        private set
        {
            this.selectionViewModel = value;
            PropertyChanged?.Invoke(this, nameof(SelectionViewModel));
        }
    }
}
You passed SelectionViewModel instance to Content property of ContentControl.
Your ContentControl must have special datatemplate coupled with this view model. Otherwise, it will not work.
For example:
<ContentControl Content="{Binding SelectionViewModel}">
    <ContentControl.ContentTemplate>
        <DataTemplate DataType="{x:Type local:SelectionViewModel}">
            <!-- Here is your template -->
        </DataTemplate>
    </ContentControl.ContentTemplate>
</ContentControl>
Also you shouldn't use same names for type SelectionViewModel and property SelectionViewModel.
Since you wasn't provide a source code we can't figure out the exact cause of your error.
I hope it was helpful for you.
