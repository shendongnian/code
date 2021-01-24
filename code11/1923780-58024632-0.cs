int nameCounter = 0;
var usernameList = new List<string> { "John", "Mike", "Bill", "Andy" };
lblUser.Text = usernameList[nameCounter];
private void lblUser_Click(object sender, EventArgs e)
{
   nameCounter = nameCounter < usernameList.Count? 0 : nameCounter + 1;
   lblUser.Text = usernameList[nameCounter];
}
