public class someclass
{
    public somelcass()
    {
        MainWindow.gridbackground = Brushes.Black;
    }
}
public class MainWindow
{
    public static Brush gridbackground = Brushes.White;
    public DispatchTimer timer;
    public MainWindow()
    {
        timer.Tick += checkbackground;
        timer.Start();
    }
    private void checkbackground(object sender, EventArgs e)
    {
        grid.Background = gridbackground;
    }
}
Creating a static variable and a dispatch timer to periodically check for changes works.
