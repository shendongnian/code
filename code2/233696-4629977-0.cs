private void Form1_Load(object sender, EventArgs e)
{
    this.gridDataBoundGrid.CurrentCellErrorMessage += new GridCurrentCellErrorMessageEventHandler(gridDataBoundGrid_CurrentCellErrorMessage);
}
void gridDataBoundGrid_CurrentCellErrorMessage(object sender, GridCurrentCellErrorMessageEventArgs e)
{
    //e.Text = "My Text";
    MessageBox.Show("Type your custom message here. The original text is: \"" + e.Text+ "\"");
    e.Cancel = true;
}
