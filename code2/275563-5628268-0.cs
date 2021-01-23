Button buttonThatTriggeredTheContextMenu; 
public void OnButtonMouseClick(object sender, MouseEventArgs e)
{
    if (e.Button == MouseButtons.Left)
        // left click stuff handling
    if (e.Button == MouseButtons.Right) {
        buttonThatTriggeredTheContextMenu = (Button)sender;
        buttonContextMenu.Show((Button)sender, new Point(e.X, e.Y));
    }
}
public void OnFooClicked(object sender, EventArgs e)
{
    //buttonThatTriggeredTheContextMenu contains the button you want
}
