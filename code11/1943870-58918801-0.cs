c#
private void Window_MouseLeave(object sender, MouseEventArgs e)
{
    // Bring mouse back to center if it leaves
    MouseX = CrosshairX;
    MouseY = CrosshairY;
    System.Windows.Forms.Cursor.Position = new System.Drawing.Point((int)CrosshairX, (int)CrosshairY);
}
