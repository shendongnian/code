// Save
var rw = new ResXResourceWriter(<your file>);
foreach (CheckBox box in Form.Controls)
{
      rw.AddResource(box.ToString(), box.Checked);
}
rw.Close();
// Read
var rr = ResXResourceReader(<your file>);
foreach (DictionaryEntry d in rr)
{
      var box = Form.Controls.First(x => x.ToString() == d.Key.ToString);
      box.Checked = (bool) d.Value;
}
rr.Close();
This probably has some errors, i did not have time to test it
