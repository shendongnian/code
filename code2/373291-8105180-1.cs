    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Linq;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using Microsoft.Phone.Shell;
    namespace LiveTilePlayground
    {
        public partial class LiveTileGenerator
        {
            /// <summary>
            /// Renders a FrameworkElement (control) to a bitmap
            /// the size of a live tile or a custom sized square.
            /// </summary>
            /// <param name="element">The element.</param>
            /// <param name="size">
            /// The size of the bitmap (in each dimension).
            /// </param>
            /// <returns></returns>
            public static WriteableBitmap RenderBitmap(
                FrameworkElement element,
                double size = 173.0)
            {
                element.Measure(new Size(size, size));
                element.Arrange(new Rect(0, 0, size, size));
                return new WriteableBitmap(element, null);
            }
            /// <summary>
            /// Updates the primary tile with specific title and background image.
            /// </summary>
            /// <param name="title">The title.</param>
            /// <param name="backgroundImage">The background image.</param>
            public static void UpdatePrimaryTile(string title, Uri backgroundImage)
            {
                ShellTile primaryTile = ShellTile.ActiveTiles.First();
                StandardTileData newTileData = new StandardTileData
                { Title = title, BackgroundImage = backgroundImage };
                primaryTile.Update(newTileData);
            }
            /// <summary>
            /// Saves the tile bitmap with a given file name and returns the URI.
            /// </summary>
            /// <param name="bitmap">The bitmap.</param>
            /// <param name="fileName">Name of the file.</param>
            /// <returns></returns>
            public static Uri SaveTileBitmap(
                WriteableBitmap bitmap, string fileName)
            {
                //MakeNonPremultiplied(bitmap.Pixels);
                using (var store = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (!store.DirectoryExists(@"Shared\ShellContent"))
                    {
                        store.CreateDirectory(@"Shared\ShellContent");
                    }
                    using (
                        var stream = store.OpenFile(
                            @"Shared\ShellContent\" + fileName,
                            FileMode.OpenOrCreate))
                    {
                        bitmap.SaveJpeg(stream, 173, 173, 0, 100);
                    }
                }
                return new Uri(
                    "isostore:/Shared/ShellContent/" + fileName, UriKind.Absolute);
            }
            /// <summary>
            /// Transforms bitmap pixels to a non-alpha premultiplied format.
            /// </summary>
            /// <param name="bitmapPixels">The bitmap pixels.</param>
            public static void MakeNonPremultiplied(int[] bitmapPixels)
            {
                int count = bitmapPixels.Length;
                // Iterate through all pixels and
                // make each semi-transparent pixel non-premultiplied
                for (int i = 0; i < count; i++)
                {
                    uint pixel = unchecked((uint)bitmapPixels[i]);
                    // Decompose ARGB structure from the uint into separate channels
                    // Shift by 3 bytes to get Alpha
                    double a = pixel >> 24;
                    // If alpha is 255 (solid color) or 0 (completely transparent) -
                    // skip this pixel.
                    if ((a == 255) || (a == 0))
                    {
                        continue;
                    }
                    // Shift 2 bytes and filter out the Alpha byte to get Red
                    double r = (pixel >> 16) & 255;
                    // Shift 1 bytes and filter out Alpha and Red bytes to get Green
                    double g = (pixel >> 8) & 255;
                    // Filter out Alpha, Red and Green bytes to get Blue
                    double b = (pixel) & 255;
                    // Divide by normalized Alpha to get non-premultiplied values
                    double factor = 256 / a;
                    uint newR = (uint)Math.Round(r * factor);
                    uint newG = (uint)Math.Round(g * factor);
                    uint newB = (uint)Math.Round(b * factor);
                    // Compose back to ARGB uint
                    bitmapPixels[i] =
                        unchecked((int)(
                            (pixel & 0xFF000000) |
                            (newR << 16) |
                            (newG << 8) |
                            newB));
                }
            }
        }
    }
