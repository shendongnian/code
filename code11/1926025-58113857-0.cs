csharp
// create Dictionary to store Button and CheckListBox
IDictionary<Button, CheckListBox> map = new Dictionary<Button, CheckListBox>();  
// when you create new order (new TableLayoutPanel)
// just add map Button and CheckListBox to map
var panel = new Panel();
panel.Size = new System.Drawing.Size(360, 500);
panel.BorderStyle = BorderStyle.FixedSingle;
panel.Name = "panel";
var table = new TableLayoutPanel();
var checklistBox = new CheckedListBox();
var button = new Button() { Text = "CheckAll" };
table.Controls.Add(button, 1, 4);
button.Name = "b1";
button.Click += new EventHandler(CheckAll_Click);
button.AutoSize = true;
map[button] = checklistBox;
// and on event handle
private void CheckAll_Click(object sender, EventArgs e)
{
    var buttonClicked = (Button)sender;                        
    var c = map[buttonClicked];
    if(c==null) return;
    // Do what you need with checkListBox here;
}
And dont for get remove it from map when remove the order.  
Hope it helps
