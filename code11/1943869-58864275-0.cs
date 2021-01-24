C#
private void Window_MouseLeave(object sender, MouseEventArgs e)
{
    //Unbind the event
    this -= Window_MouseMove;
    // Bring mouse back to center if it leaves
    System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)CrosshairX, (int)CrosshairY);
    
    //Rebind the event
    this += Window_MouseMove;
}
