<CustomTable Id="App">
    <Text>bla bla</Text>
</CustomTable>
Then you can read from it in a c# custom action by creating a View query to find the desired properties:
using (View view = session.Database.OpenView("SELECT 'Text' FROM 'App'"))
{
    view.Execute();
    // access view properties and turn them into some object you want to manipulate
}
I'll admit some ignorance as to what that view object is going to have, but I know you can iterate through its records or grab individual columns, poking around in the properties should eventually find you the values you want.
Next step is to populate a combobox element with the values
<Control Id="DropdownSelectLabel" Type="Text" X="50" Y="65" Width="200" Height="15" TabSkip="no" Text="&amp;Select a value:">
</Control>
<Control Id="DropdownSelect" Type="ComboBox" Height="16" Width="200" X="60" Y="80" Property="MY_PROPERTY_KEY" ComboList="yes">
    <ComboBox Property="MY_PROPERTY_KEY">
        <!-- Optional prepopulate value-->
        <ListItem Text="[dummy_text]" Value="[dummy_value]" />
    </ComboBox>
</Control>
I'm populating it with a custom c# action running during the InstallUISequence, built through visual studio
<!-- Custom action for populating the combobox -->
<CustomAction Id="CA_PopulateComboBox" BinaryKey="BIN_CustomActions" DllEntry="PopulateComboBox" Execute="firstSequence" />
<!-- Binaries for the custom action -->
<Binary Id="BIN_CustomActions" SourceFile="..\PATH-TO-YOUR-CUSTOM-ACTION-BIN-RELEASE.CA.dll" />
<!-- Schedule the custom action -->
<InstallUISequence>
    <Custom Action="CA_PopulateComboBox" Before="LaunchConditions" />
</InstallUISequence>
Custom action looks like this:
public class CustomActions
{
    /// <summary>
    /// Populates the ComboBox UI Element.
    /// </summary>
    /// <param name="session">The session.</param>
    [CustomAction]
    public static void PopulateComboBox(Session session)
    {
        session.Log("Populating the combobox with certificates");
        // Clear the combobox (unecessary if it starting empty)
        View view = session.Database.OpenView("DELETE FROM ComboBox WHERE ComboBox.Property='MY_PROPERTY_KEY'");
        view.Execute();
        view = session.Database.OpenView("SELECT * FROM ComboBox");
        view.Execute();
        // Get the certs
        List<ComboBoxRecordWrapper> valuesToAdd = PopulateValuesObjects(session); // Add the logic to read your xml values from the session object here
        var index = 1;
        foreach (ComboBoxRecordWrapper valueObject in valuesToAdd)
        {
            session.Log($"Adding value to the combobox: {valueObject.Text} - {valueObject.Value} {Environment.NewLine}Order: {valueObject.Order}");
            view.Modify(ViewModifyMode.InsertTemporary, recordWrapper.ToRecord());
            view.Execute();
            index++;
        }
        view.Close();
    }
}
/// <summary>
/// Class ComboBoxRecordWrapper. Wraps objects that should be represented in a combobox element in the installer
/// </summary>
public class ComboBoxRecordWrapper
{
    /// <summary>
    /// Gets or sets the property that this element's value will be stored as if the element is selected
    /// </summary>
    /// <value>The property.</value>
    public string Property { get; set; }
    /// <summary>
    /// Gets or sets the order that this element appears in the combobox
    /// </summary>
    /// <value>The order.</value>
    public int Order { get; set; }
    /// <summary>
    /// Gets or sets the value of the combobox option. This is what will be available to the UI element as a returned value
    /// </summary>
    /// <value>The value.</value>
    public string Value { get; set; }
    /// <summary>
    /// Gets or sets the text that will be displayed for this element
    /// </summary>
    /// <value>The text.</value>
    public string Text { get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="ComboBoxRecordWrapper"/> class.
    /// </summary>
    /// <param name="property">The property.</param>
    /// <param name="order">The order.</param>
    /// <param name="value">The value.</param>
    /// <param name="text">The text.</param>
    public ComboBoxRecordWrapper(string property, int order, string value, string text)
    {
        this.Property = property;
        this.Order = order;
        this.Value = value;
        this.Text = string.IsNullOrEmpty(text) ? value : text;
    }
    /// <summary>
    /// Converts to a record to add to the MSI database.
    /// </summary>
    /// <returns>Record.</returns>
    public Record ToRecord()
    {
        var record = new Record(4);
        record.SetString(1, this.Property);
        record.SetInteger(2, this.Order);
        record.SetString(3, this.Value);
        record.SetString(4, this.Text);
        return record;
    }
}
  [1]: http://blog.iswix.com/2008/05/data-driven-managed-custom-actions-made.html
