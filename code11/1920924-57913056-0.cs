lang-csharp
// Data.cs
namespace WindowsFormsApplication
{
   public class Data
   {
      public int State { get; set; }
      public string Tip { get; set; }
   }
}
// Form1.cs
using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication
{
   public partial class Form1 : Form
   {
      public Form1()
      {
         InitializeComponent();
         var rng = new Random();
         _data = new Data[30 * 30];
         for (int i = 0; i < _data.Length; i++)
         {
            _data[i] = new Data
            {
               State = rng.Next(0, 3),
               Tip = $"Data at index: {i}"
            };
         }
      }
      private Data[] _data;
      private void panel1_Paint(object sender, PaintEventArgs e)
      {
         using (var brush = new SolidBrush(Color.Gray))
         using (var buffer = BufferedGraphicsManager.Current.Allocate(e.Graphics,
            new Rectangle(0, 0, 450, 450)))
         {
            for (int x = 0; x < 30; x++)
            {
               for (int y = 0; y < 30; y++)
               {
                  int dataIdx = (y * 30) + x;
                  Data data = _data[dataIdx];
                  if (data.State == 1)
                  {
                     brush.Color = Color.Blue;
                  }
                  else if (data.State == 2)
                  {
                     brush.Color = Color.Red;
                  }
                  else
                  {
                     brush.Color = Color.Gray;
                  }
                  buffer.Graphics.FillRectangle(brush, x * 15, y * 15, 15, 15);
                  buffer.Graphics.DrawLine(Pens.Black, 0, y * 15, 450, y * 15); //Gridline
               }
               buffer.Graphics.DrawLine(Pens.Black, x * 15, 0, x * 15, 450); //Gridline
            }
            buffer.Render(e.Graphics);
         }
      }
      private void panel1_MouseMove(object sender, MouseEventArgs e)
      {
         var point = e.Location;
         int x = point.X / 15;
         int y = point.Y / 15;
         int dataIdx = (y * 30) + x;
         System.Diagnostics.Debug.WriteLine(_data[dataIdx].Tip);
      }
   }
}
The `Data` class represents the model behind each segment on the panel and is pretty straight forward.
`Form1` has a single control placed on it: a `Panel` named `panel1` with a size of `450 x 450`. Each cell on the panel will be `15 x 15`, so we have 30 columns and 30 rows. In `Form1`'s constructor, we initialize the `Data` that will be used to draw the panel.
Inside of `Form1.panel1_Paint` we iterate through the cells and look up the instance of `Data` for the given cell. Then, based on the `State`, set a color for the cell and draw a rectangle of that color. This is done on a buffer so the panel doesn't flicker when painting.
Inside of `Form1.panel1_MouseMove` we use the location of the mouse pointer relative to `panel1` to figure out which cell the mouse is over, get the instance of `Data` for that cell, and display the `Tip` in the debug window.
You might be able to take this and build upon it, perhaps with a custom `UserControl` so you can easily access each individual cell with the column and row... your `box[x, y].Color = Colors.Green` example above. 
