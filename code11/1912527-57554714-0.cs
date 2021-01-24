using System;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
class ExampleForm : Form
{
    /// <summary>
    /// Main method (just to run a form)
    /// </summary>
    [STAThread]
    private static void Main()
    {
        Application.Run(new ExampleForm());
    }
    //All the variables
    private Point startingPoint = Point.Empty;
    private Point movingPoint = Point.Empty;
    private bool panning;
    /// <summary>
    /// Main panel. Technically, drawing can be done on the form itself.
    /// Creting a panel to keep it similar with original example
    /// </summary>
    private TableLayoutPanel tableLayoutPanel;
    private ExampleForm()
    {
        InitiailizeComponent();
        //not sure if this one is necessary for example
        //keeping it to keep as close as possible to original code
        typeof(Panel).InvokeMember("DoubleBuffered",
            BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            null, tableLayoutPanel, new object[] { true });
    }
    /// <summary>
    /// For simplicity just a panel, filling a form
    /// Also, event handlers
    /// </summary>
    private void InitiailizeComponent()
    {
        //background image for panel
        var backgroundImage = new Bitmap(10, 10);
        var graphics = Graphics.FromImage(backgroundImage);
        graphics.FillRectangle(Brushes.Red, 0, 0, 10,10);
        Load += TableLayoutPanel_Load;
        tableLayoutPanel = new TableLayoutPanel {Dock = DockStyle.Fill, BackgroundImage = backgroundImage};
        tableLayoutPanel.MouseDown += TableLayoutPanel_MouseDown;
        tableLayoutPanel.MouseUp += TableLayoutPanel_MouseUp;
        tableLayoutPanel.MouseMove += TableLayoutPanel_MouseMove;
        tableLayoutPanel.Paint += TableLayoutPanel_Paint;
        Controls.Add(tableLayoutPanel);
    }
    /// <summary>
    /// Create another form next to the main form when main form loads
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void TableLayoutPanel_Load(object sender, EventArgs e)
    {
        //if this is the main form of an application
        if (Application.OpenForms.Count != 1) return;
        //create and show another form
        var another = new ExampleForm
        {
            StartPosition = FormStartPosition.Manual, 
            Location = new Point(Location.X + Width, Location.Y)
        };
        another.Show();
    }
    //exact copy
    private void TableLayoutPanel_MouseUp(object sender, MouseEventArgs e)
    {
        panning = false;
    }
    //exact copy
    private void TableLayoutPanel_MouseDown(object sender, MouseEventArgs e)
    {
        panning = true;
        startingPoint = new Point(e.Location.X - movingPoint.X,
            e.Location.Y - movingPoint.Y);
    }
    
    //exact copy
    private void TableLayoutPanel_MouseMove(object sender, MouseEventArgs e)
    {
        if (panning)
        {
            int xLocation = e.Location.X;
            if (e.Location.X < 0)
                xLocation = 0;
            if (e.Location.X > tableLayoutPanel.Width)
                xLocation = tableLayoutPanel.Width;
            int yLocation = e.Location.Y;
            if (e.Location.Y < 0)
                yLocation = 0;
            if (e.Location.Y > tableLayoutPanel.Height)
                yLocation = tableLayoutPanel.Height;
            movingPoint = new Point(xLocation - startingPoint.X,
                yLocation - startingPoint.Y);
            tableLayoutPanel.Invalidate();
            var openForms = Application.OpenForms.OfType<ExampleForm>().Where(display => !GetHashCode().Equals(display.GetHashCode())).ToList();
            foreach (var mapRunnerDisplay in openForms)
            {
                mapRunnerDisplay.UpdateMapPosition(movingPoint);
            }
        }
    }
    //exact copy
    private void UpdateMapPosition(Point point)
    {
        movingPoint = point;
        tableLayoutPanel.Invalidate();
    }
    //exact copy
    private void TableLayoutPanel_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Black);
        e.Graphics.DrawImage(tableLayoutPanel.BackgroundImage, movingPoint);
    }
}
And here's the result:
[![two forms with a red square being dragged][1]][1]
As you can see, as I'm padding the background image (red square) on one form, it's position is getting updated in another one.
You probably need to:
 - run this code and verify that it works for you too;
 - figure out what's the difference between your code and this example;
 - create a complete, reproducible example of your own.
Some parts of your code are not included in the question. You might want to post:
 - contents of `ExampleForm.desinger.cs`, in particularly `InitializeComponents` method;
 - a background image of `tableLayoutPanel1`;
 - the calling code, that creates multiple instances of `ExampleForm`.
Good luck :)
  [1]: https://i.stack.imgur.com/54Og4.gif
