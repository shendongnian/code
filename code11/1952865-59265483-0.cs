private void listBox_SelectedIndexChanged(object sender, System.EventArgs e)
{
   string itemSelected = listBox.SelectedItem.ToString();
   textBox.Text = itemSelected;
}
