private IEnumerable<RadioButton> GetRadioButtons(Control container, string groupName)
{
    return container.Controls
        .OfType<RadioButton>()
        .Where(i => i.GroupName == groupName);
}
For instance, if the radio buttons with the group name "Gr1" are immediate children of your form, you can get them like this:
var radioButtons = GetRadioButtons(Form, "Gr1");
Checking if any of them are checked could be done like this:
var radioButtonCheckedInGr1 = GetRadioButtons(Form, "Gr1").Any(i => i.Checked);
Hope this helps.
