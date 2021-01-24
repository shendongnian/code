c#
using (StreamReader reader = new StreamReader("text.ini"))
{
    while (true)
    {
    string line = reader.ReadLine();
    if (line== null)
        break;
    ToolStripMenuItem menu = new ToolStripMenuItem(line);
    menu.Click += new EventHandler(menu_Click);
    favsToolStripMenuItem.DropDown.Items.Add(menu);
    }
}
Now, each submenu item has its own event to trigger when clicked. This is how you select which event to trigger based on the name/text of the item,
c#
void menu_Click(object sender, EventArgs e)
{
    var menuItem = sender as MenuItem; 
    var menuText = menuItem.Text;
    switch(menuText) {
        case "MenuItem1":
           // menu item1 clicked .. do something 
           break;
        case "MenuItem2":
          // menu item2 clicked .. do something 
          break;
         . ...
}
