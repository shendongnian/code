csharp
// example of custom type and simple DataTemplateSelector
public class YourItemType
{ 
    public string Property { get; set; }
}
public class YourTemplateSelector : DataTemplateSelector
{
    public DataTemplate TextTemplate { get; set; }
    public DataTemplate ComboTemplate { get; set; }
    public override DataTemplate SelectTemplate(object item, DependencyObject container)
    {
        return (item is YourItemType yourItem && yourItem.Property.Equals("condition here")) ? ComboTemplate : TextTemplate;
    }
}
xaml
<!--Somewhere in static resources-->
<DataTemplate x:Key="comboTemplate">
    <ComboBox IsEditable='False'
              ItemsSource='{Binding YourItemsSource}' SelectedItem='{Binding Property}'
              Text='{Binding Property}' />
</DataTemplate>
        
<DataTemplate x:Key="textTemplate">
    <ComboBox Text='{Binding Property}' />
</DataTemplate>
<local:YourTemplateSelector x:Key='YourTemplateSelector'
                            TextTemplate='{StaticResource textTemplate}'
                            ComboTemplate='{StaticResource comboTemplate}' />
[DataGridTemplateColumn]: <https://docs.microsoft.com/it-it/dotnet/api/system.windows.controls.datagridtemplatecolumn?view=netframework-4.8>
[DataTemplateSelector]: <https://docs.microsoft.com/en-us/dotnet/api/system.windows.controls.datatemplateselector?view=netframework-4.8>
