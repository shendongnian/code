    class Program {
        static void Main(string[] args) {
            Image full = Image.FromFile("foo.png");
            Image cropped = full.TrimOnBottom();
        }
    }
    public static class ImageUtilities {
        public static Image TrimOnBottom(this Image image, Color? backgroundColor = null, int margin = 30) {
            var bitmap = (Bitmap)image;
            int foundContentOnRow = -1;
            // handle empty optional parameter
            var backColor = backgroundColor ?? Color.White;
            // scan the image from the bottom up, left to right
            for (int y = bitmap.Height - 1; y >= 0; y--) {
                for (int x = 0; x < bitmap.Width; x++) {
                    Color color = bitmap.GetPixel(x, y);
                    if (color.R != backColor.R || color.G != backColor.G || color.B != backColor.B) {
                        foundContentOnRow = y;
                        break;
                    }
                }
                // exit loop if content found
                if (foundContentOnRow > -1) {
                    break;
                }
            }
            if (foundContentOnRow > -1) {
                int proposedHeight = foundContentOnRow + margin;
                // only trim if proposed height smaller than existing image
                if (proposedHeight < bitmap.Height) {
                    return CropImage(image, bitmap.Width, proposedHeight);
                }
            }
            return image;
        }
        private static Image CropImage(Image image, int width, int height) {
            Rectangle cropArea = new Rectangle(0, 0, width, height);
            Bitmap bitmap = new Bitmap(image);
            return bitmap.Clone(cropArea, bitmap.PixelFormat);
        }
    }
