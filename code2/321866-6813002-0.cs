        public class NineSliceBitmapSnippet
    {
        private Bitmap m_OriginalBitmap;
        public int CornerLength { get; set; }
        public NineSliceBitmapSnippet(Bitmap bitmap)
        {
            CornerLength = 5;
            m_OriginalBitmap = bitmap;
        }
        public Bitmap Scale(Size size)
        {
            if (m_OriginalBitmap != null)
            {
                return ScaleSingleBitmap(size);
            }
            return null;
        }
        public Bitmap ScaleSingleBitmap(Size size)
        {
            Bitmap scaledBitmap = new Bitmap(size.Width, size.Height);
            int[] horizontalTargetSlices = Slice(size.Width);
            int[] verticalTargetSlices = Slice(size.Height);
            int[] horizontalSourceSlices = Slice(m_OriginalBitmap.Width);
            int[] verticalSourceSlices = Slice(m_OriginalBitmap.Height);
            using (Graphics graphics = Graphics.FromImage(scaledBitmap))
            {
                using (Brush brush = new SolidBrush(Color.Fuchsia))
                {
                    graphics.FillRectangle(brush, new Rectangle(0, 0, size.Width, size.Height));
                }
                int horizontalTargetOffset = 0;
                int verticalTargetOffset = 0;
                int horizontalSourceOffset = 0;
                int verticalSourceOffset = 0;
                for (int x = 0; x < horizontalTargetSlices.Length; x++)
                {
                    verticalTargetOffset = 0;
                    verticalSourceOffset = 0;
                    for (int y = 0; y < verticalTargetSlices.Length; y++)
                    {
                        Rectangle destination = new Rectangle(horizontalTargetOffset, verticalTargetOffset, horizontalTargetSlices[x], verticalTargetSlices[y]);
                        Rectangle source = new Rectangle(horizontalSourceOffset, verticalSourceOffset, horizontalSourceSlices[x], verticalSourceSlices[y]);
                        bool isWidthAffectedByVerticalStretch = (y == 1 && (x == 0 || x == 2) && destination.Height > source.Height);
                        bool isHeightAffectedByHorizontalStretch = (x == 1 && (y == 0 || y == 2) && destination.Width > source.Width);
                        if (isHeightAffectedByHorizontalStretch)
                        {
                            BypassDrawImageError(graphics, destination, source, Orientation.Horizontal);
                        }
                        else if (isWidthAffectedByVerticalStretch)
                        {
                            BypassDrawImageError(graphics, destination, source, Orientation.Vertical);
                        }
                        else
                        {
                            graphics.DrawImage(m_OriginalBitmap, destination, source, GraphicsUnit.Pixel);
                        }
                        verticalTargetOffset += verticalTargetSlices[y];
                        verticalSourceOffset += verticalSourceSlices[y];
                    }
                    horizontalTargetOffset += horizontalTargetSlices[x];
                    horizontalSourceOffset += horizontalSourceSlices[x];
                }
            }
            return scaledBitmap;
        }
        private void BypassDrawImageError(Graphics graphics, Rectangle destination, Rectangle source, Orientation orientationAdjustment)
        {
            Size adjustedSize = Size.Empty;
            switch (orientationAdjustment)
            {
                case Orientation.Horizontal:
                    adjustedSize = new Size(destination.Width, destination.Width);
                    break;
                case Orientation.Vertical:
                    adjustedSize = new Size(destination.Height, destination.Height);
                    break;
                default:
                    break;
            }
            using (Bitmap quadScaledBitmap = new Bitmap(adjustedSize.Width, adjustedSize.Height))
            {
                using (Graphics tempGraphics = Graphics.FromImage(quadScaledBitmap))
                {
                    tempGraphics.Clear(Color.Fuchsia);
                    tempGraphics.DrawImage(m_OriginalBitmap, new Rectangle(0, 0, adjustedSize.Width, adjustedSize.Height), source, GraphicsUnit.Pixel);
                }
                graphics.DrawImage(quadScaledBitmap, destination, new Rectangle(0, 0, quadScaledBitmap.Width, quadScaledBitmap.Height), GraphicsUnit.Pixel);
            }
        }
        public int[] Slice(int length)
        {
            int cornerLength = CornerLength;
            if (length <= (cornerLength * 2))
                throw new Exception("Image to small for sliceing up");
            int[] slices = new int[3];
            slices[0] = cornerLength;
            slices[1] = length - (2 * cornerLength);
            slices[2] = cornerLength;
            return slices;
        }
    }
