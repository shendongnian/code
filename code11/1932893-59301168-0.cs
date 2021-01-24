C#
private void Window_MouseDown(object sender, MouseButtonEventArgs e)
{
     if (e.ChangedButton == MouseButton.Left)
     {
          this.ResizeMode = ResizeMode.NoResize;
          this.DragMove();
          this.ResizeMode = ResizeMode.CanResizeWithGrip;
     }
}
For **overriding the Windows Key + Arrow combination**, I did a similar thing by catching the Windows Key press in Preview Key Up/Down:
C#
private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
{
     if (e.Key == Key.LWin || e.Key == Key.RWin)
     {
          this.ResizeMode = ResizeMode.NoResize;
     }
}
private void Window_PreviewKeyUp(object sender, KeyEventArgs e)
{
     if (e.Key == Key.LWin || e.Key == Key.RWin)
     {
          this.ResizeMode = ResizeMode.CanResizeWithGrip;
     }
}
I suppose you could also catch the arrow key press after the Window Key if you wanted to modify this key combination to do something else (such as moving to a different window, but not resizing). 
If anyone has a better solution, I'm all ears, but this seemed to work for me and seemed pretty simple. 
