csharp
else if (Catch1ComboBox.SelectedIndex != -1 && NumericAmount1.Value == 0 ||
Catch2ComboBox.SelectedIndex != -1 && NumericAmount2.Value == 0 ||
Catch3ComboBox.SelectedIndex != -1 && NumericAmount3.Value == 0 ||
Catch4ComboBox.SelectedIndex != -1 && NumericAmount4.Value == 0)
{
    MessageBox.Show("Please Input Amount Of Fish Caught", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
} 
to 
csharp
else if (Catch1ComboBox.SelectedIndex != -1 && 
  (NumericAmount1.Value == 0 
   || NumericAmount2.Value == 0 
   || NumericAmount3.Value == 0 
   || NumericAmount4.Value == 0)
) {
    MessageBox.Show("Please Input Amount Of Fish Caught", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
} 
When logic gets complicated, sometimes it better to flip the logic into their own types.
csharp
var List<Func<Action>> errorConditions = new List<Func<bool>>()
{
  () => {
    var result = Catch1ComboBox.SelectedIndex != -1 
    && (NumericAmount1.Value == 0 
        || NumericAmount2.Value == 0 
        || NumericAmount3.Value == 0 
        || NumericAmount4.Value == 0);
    ? () => { 
      MessageBox.Show("Please Input Amount Of Fish Caught",
        "ERROR", 
        MessageBoxButtons.OK, 
        MessageBoxIcon.Error);
    }
    : null as Action;
  },
  () => {
    // return some other action if some condition
  }
};
Then it's the code looks like:
csharp
var action = errorConditions.FirstOrDefault();
if (action != null) {
  action();
} else {
  // no error condition
}
