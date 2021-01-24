int nameCounter = 0; // Variable to track displayed element
var usernameList = new List<string> { "John", "Mike", "Bill", "Andy" }; // list of values to cycle
lblUser.Text = usernameList[nameCounter++];
private void lblUser_Click(object sender, EventArgs e)
{
   nameCounter = nameCounter < usernameList.Count ? nameCounter : 0;
   lblUser.Text = usernameList[nameCounter++];
}
