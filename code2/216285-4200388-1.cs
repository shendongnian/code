    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System;
    using System.Windows.Controls;
    using System.Windows;
    using System.Windows.Shapes;
    namespace WpfApplication30
    {
        class ImageEditor
        {
            public static void processImage(string loc)
            {
                ImageSource ic = new BitmapImage(new Uri(loc, UriKind.Relative));
                ImageBrush brush = new ImageBrush(ic);
                Path p = new Path();
                p.Fill = brush;
                CombinedGeometry cb = new CombinedGeometry();
                cb.GeometryCombineMode = GeometryCombineMode.Exclude;
                EllipseGeometry ellipse = new EllipseGeometry(new Point(50, 50), 5, 5);
                RectangleGeometry rect = new RectangleGeometry(new Rect(new Size(100, 100)));
                cb.Geometry1 = rect;
                cb.Geometry2 = ellipse;
                p.Data = cb;
    
                Canvas inkCanvas1 = new Canvas();
                inkCanvas1.Children.Add(p);
                inkCanvas1.Height = 96;
                inkCanvas1.Width = 96;
    
                inkCanvas1.Measure(new Size(96, 96));
                inkCanvas1.Arrange(new Rect(new Size(96, 96)));
                RenderTargetBitmap targetBitmap =
        new RenderTargetBitmap((int)inkCanvas1.ActualWidth,
                               (int)inkCanvas1.ActualHeight,
                               96d, 96d,
                               PixelFormats.Default);
                targetBitmap.Render(inkCanvas1);
    
                using (System.IO.FileStream outStream = new System.IO.FileStream( loc.Replace(".png","Copy.png"), System.IO.FileMode.Create))
                {
                    PngBitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(targetBitmap));
                    encoder.Save(outStream);
                }
            }
        }
    }
