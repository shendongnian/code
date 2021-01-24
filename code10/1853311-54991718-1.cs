    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using System.Windows.Shapes;
    
    namespace StackOverflow54985848
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                // Get the rectangles from the canvas
                var rects = canvas.Children
                    .Cast<Rectangle>()
                    .Select(r => new Rect(
                        (double)r.GetValue(Canvas.LeftProperty),
                        (double)r.GetValue(Canvas.TopProperty),
                        r.Width, r.Height))
                        .ToArray();
    
                // Determine the bounds of the rects
                var minX = rects.Min(r => r.Left);
                var maxX = rects.Max(r => r.Right);
                var minY = rects.Min(r => r.Top);
                var maxY = rects.Max(r => r.Bottom);
                var bounds = new Rect(minX, minY, maxX - minX, maxY - minY);
    
                // openSpace initially is the entire area
                List<Rect> openSpace = new List<Rect>() { bounds };
    
                // Remove r from all rects in openSpace
                foreach (var r in rects)
                {
                    List<Rect> openSpaceToRemove = new List<Rect>();
                    List<Rect> openSpaceToAdd = new List<Rect>();
    
                    foreach (var os in openSpace)
                    {
                        if (!os.IntersectsWith(r))
                            continue;
                        var r2 = os;
                        r2.Intersect(r); // result stored in r2, it is the area that isn't open anymore
    
                        // We will be removing os since it intersects
                        openSpaceToRemove.Add(os);
    
                        // Remove r2 from os
                        //
                        // Probably a better way to do this...
                        // We have the area that ISNT open (r2) but we want the area that IS open still
                        // Create 4 rects that cover the area OUTSIDE of r2 (to the left, right, above, below)
                        // The intersection of those rects and os is our still open space (subset of os)
    
                        // Create a rect that is everything to the left of r2 and intersect it with os
                        var rr = new Rect(bounds.Left, bounds.Top, r2.Left, bounds.Height);
                        rr.Intersect(os); // intersection is stored in rr
                        if (rr.Width > 0 && rr.Height > 0)
                            openSpaceToAdd.Add(rr);
    
                        // Repeat with everything to the right
                        rr = new Rect(r2.Right, bounds.Top, bounds.Right - r2.Right, bounds.Height);
                        rr.Intersect(os); // intersection is stored in rr
                        if (rr.Width > 0 && rr.Height > 0)
                            openSpaceToAdd.Add(rr);
    
                        // Repeat with everything above the top
                        rr = new Rect(bounds.Left, r2.Top - bounds.Height, bounds.Width, bounds.Height);
                        rr.Intersect(os); // intersection is stored in rr
                        if (rr.Width > 0 && rr.Height > 0)
                            openSpaceToAdd.Add(rr);
    
                        // Repeat with everything below the bottom
                        rr = new Rect(bounds.Left, r2.Bottom, bounds.Width, bounds.Height);
                        rr.Intersect(os); // intersection is stored in rr
                        if (rr.Width > 0 && rr.Height > 0)
                            openSpaceToAdd.Add(rr);
                    }
    
                    // Remove rects we don't want
                    foreach (var os in openSpaceToRemove)
                        openSpace.Remove(os);
                    // Add rects we do want
                    openSpace.AddRange(openSpaceToAdd);
                }
    
                // Now that our openspace has been determined, add it to the canvas
                foreach (var r in openSpace)
                {
                    var rr = new Rectangle()
                    {
                        Width = r.Width,
                        Height = r.Height,
                        Fill = Brushes.Beige,
                        Stroke = Brushes.Red,
                        StrokeThickness = 1.0
                    };
                    rr.SetValue(Canvas.LeftProperty, r.Left);
                    rr.SetValue(Canvas.TopProperty, r.Top);
                    canvas.Children.Add(rr);
    
                    // Grid to hold the textblock (more control over width/height)
                    var grid = new Grid()
                    {
                        Width = r.Width,
                        Height = r.Height,
                    };
                    grid.SetValue(Canvas.LeftProperty, r.Left);
                    grid.SetValue(Canvas.TopProperty, r.Top);
                    TextBlock tb = new TextBlock()
                    {
                        Text = $"Width: {rr.Width} Height: {rr.Height}",
                        Foreground = Brushes.Red,
                        VerticalAlignment = VerticalAlignment.Center,
                        HorizontalAlignment = HorizontalAlignment.Center,
                        TextWrapping = TextWrapping.Wrap
                    };
                    grid.Children.Add(tb);
                    canvas.Children.Add(grid);
                }
            }
        }
    }
