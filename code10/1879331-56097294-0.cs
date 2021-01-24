C#
public class SomeModel
{
    public string Abbreviation { get; set; }
    public string Content { get; set; }
    public SomeModel(string abbreviation, string content)
    {
        Abbreviation = abbreviation;
        Content = content;
    }
}
In this case the `ComboBox` would look like this:
XML
<ComboBox x:Name="cmbStates" IsEditable="True" SelectedValuePath="Abbreviation" DisplayMemberPath="Content" SelectionChanged="cmbStates_SelectionChanged" />
This way the **Abbreviation** property is the actuall value of the `ComboBoxItem` and the **Content** is used as the display for the `ComboBox`. Now your `MainWindow` constructor would look like this:
C#
public MainWindow()
{
    InitializeComponent();
    cmbStates.ItemsSource = new List<SomeModel>
    {
        new SomeModel("OH","Ohio"), new SomeModel("VA","Virginia"), new SomeModel("CA","California "),
        new SomeModel("TN","Tennessee"), new SomeModel("DE","Delaware")
    };
    cmbStates.SelectedValue = "CA";
}
Besides this case, I would advise yout to look into [WPF data binding](https://docs.microsoft.com/en-us/dotnet/framework/wpf/data/data-binding-wpf) and [WPF MVVM pattern](https://stackoverflow.com/questions/1405739/mvvm-tutorial-from-start-to-finish).
