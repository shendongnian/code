lang-csharp
private void LstBoxOne_SelectedIndexChanged(object sender, EventArgs e)
{
   var deleteD = lstBoxOne.SelectedIndex;
   lstBoxTwo.SelectedIndex = deleteD;
   lstBoxThree.SelecteIndex = deleteD;
}
private void DeleteBtn_Click(object sender, EventArgs e)
{
   lstBoxOne.Items.RemoveAt(lstBoxOne.SelectedIndex); //This line triggers the SelectedIndexChanged event on lstBoxOne.
   // By the time we get back to this function, lstBoxTwo and lstBoxThree have had 
   // their SelectedIndex set to -1. That is what is causing the exception to occur.
   lstBoxTwo.Items.RemoveAt(lstBoxTwo.SelectedIndex); //Ooops! lstBoxTwo.SelectedIndex was set to -1 in LstBoxOne_SelectedIndexChanged.
}
A simple way to correct this would be to store the selected index of each `ListBox` before trying to remove any items. Also, protect yourself by checking for `-1`.
private void DeleteBtn_Click(object sender, EventArgs e)
{
   int lstBoxOneIdx = lstBoxOne.SelectedIndex;
   int lstBoxTwoIdx = lstBoxTwo.SelectedIndex;
   int lstBoxthreeIdx = lstBoxThree.SelectedIndex;
   if (lstBoxOneIdx > -1)
   {
      lstBoxOne.Items.RemoveAt(lstBoxOneIdx);
   }
   if (lstBoxTwoIdx > -1)
   {
      lstBoxTwo.Items.RemoveAt(lstBoxTwoIdx);
   }
  
   if (lstBoxThreeIdx > -1)
   {
      lstBoxThree.Items.RemoveAt(lstBoxThreeIdx);
   }
}
