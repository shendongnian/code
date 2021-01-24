csharp
public class ComboBoxItem
{
    public string ComboBoxOption { get; set; }
    public string ComboBoxHumanReadableOption { get; set; }
    public override bool Equals(object obj)
    {
        return obj is ComboBoxItem item &&
               ComboBoxOption == item.ComboBoxOption;
    }
}
3. Modify the structure of `ComboBoxItemConvert` and add a dataset
csharp
public class ComboBoxItemConvert : IValueConverter
{
    public ObservableCollection<ComboBoxItem> Options { get; set; }
    public object Convert(object value, Type targetType, object parameter, string language)
    {
        if (value !=null && value.GetType().Equals(typeof(ComboBoxItem)))
        {
            return value;
        }
        var newItem = new ComboBoxItem() { ComboBoxOption = "new", ComboBoxHumanReadableOption = "new" };
        if(Options!=null && !Options.Contains(newItem))
        {
            Options.Add(newItem);
        }
        return newItem;
    }
    public object ConvertBack(object value, Type targetType, object parameter, string language)
    {
        return value as ComboBoxItem;
    }
}
**Usage**
xml
<local:ComboBoxItemConvert x:Key="ComboBoxItemConvert" Options="{x:Bind ComboBoxOptions}" />
When you enter an item that is not in the default data set (`ComboBoxOptions`) and press `Enter`, a new `ComboBoxItem` is added to the data set as the selected item.
---
If you need to enter custom text and generate new entries accordingly, you need to add something new.
**MainPage.xaml.cs**
csharp
private string _editText;
public string EditText
{
    get => _editText;
    set { _editText = value; RaisePropertyChanged("EditText"); }
}
**Converter**
csharp
...
public string ComboBoxEditText { get; set; }
...
public object Convert(object value, Type targetType, object parameter, string language)
{
    ...
    var newItem = new ComboBoxItem() { ComboBoxOption = ComboBoxEditText ?? "new", ComboBoxHumanReadableOption = ComboBoxEditText ?? "new" };
    if (Options != null && !Options.Contains(newItem))
    {
        Options.Add(newItem);
    }
    return newItem;
}
**MainPage.xaml**
xml
<Page.Resources>
    <local:ComboBoxItemConvert x:Key="ComboBoxItemConvert" Options="{x:Bind ComboBoxOptions}" ComboBoxEditText="{x:Bind EditText,Mode=OneWay}"/>
</Page.Resources>
...
<ComboBox Name="ComboBox"
      ...
      IsEditable="True"
      IsTextSearchEnabled="True"
      Text="{x:Bind EditText,Mode=TwoWay}"
      ...
      />
...
This will fulfill your requirements.
Best regards.
