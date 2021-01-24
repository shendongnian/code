Command="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGrid}}, Path=DataContext.DeleteCommentCommand}"
You can also update your command a little bit, by passing a parameter to `RelayCommand` and `Delete` method
public MyViewModel()
{
   DeleteCommentCommand = new RelayCommand(item => Delete(item));
}
void Delete(object item)
{
}
and pass the value in xaml `CommandParameter="{Binding}"`
