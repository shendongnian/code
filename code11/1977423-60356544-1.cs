// Save
var rw = new ResXResourceWriter(<your file>);
foreach (CheckBox box in Form.Controls)
{
    rw.AddResource(box.ToString(), box.Checked);
}
rw.Close();
// Read
var rr = ResXResourceReader(<your file>);
foreach (DictionaryEntry entry in rr)
{
    var box = Form.Controls
               .First(x => x.ToString() == entry.Key.ToString());
    box.Checked = (bool)entry.Value;
}
rr.Close();
This probably has some errors, i did not have time to test it
