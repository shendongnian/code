    public class BoldedFirstLineToolTip : ToolTip
    {
        public BoldedFirstLineToolTip()
        {
            this.OwnerDraw = true;
            this.Draw += new DrawToolTipEventHandler(OnDraw);
        }
        private void OnDraw(object sender, DrawToolTipEventArgs e)
        {
            // Try to draw using the visual style renderer.
            if (VisualStyleRenderer.IsSupported && VisualStyleRenderer.IsElementDefined(VisualStyleElement.ToolTip.Standard.Normal))
            {
                var bounds = e.Bounds;
                var renderer = new VisualStyleRenderer(VisualStyleElement.ToolTip.Standard.Normal);
                renderer.DrawBackground(e.Graphics, bounds);
                var color = renderer.GetColor(ColorProperty.TextColor);
                var text = e.ToolTipText;
                using (var textBrush = new SolidBrush(renderer.GetColor(ColorProperty.TextColor)))
                using (var font = e.Font)
                {
                    // Fix the positioning of the bounds for the text rectangle.
                    var rendererBounds = new Rectangle(e.Bounds.X + 6, e.Bounds.Y + 2, e.Bounds.Width - 6 * 2, e.Bounds.Height - 2 * 2);
                    if (!text.Contains('\n'))
                    {
                        renderer.DrawText(e.Graphics, rendererBounds, text);
                    }
                    else
                    {
                        var lines = text.Split('\n').Select(l => l.Trim());
                        var first = lines.First();
                        var otherLines = Environment.NewLine + String.Join(Environment.NewLine, lines.Skip(1).ToArray());
                        // Draw the first line.
                        using (var boldFont = new Font(font, FontStyle.Bold))
                        {
                            e.Graphics.DrawString(first, boldFont, textBrush, rendererBounds.X - 1, rendererBounds.Y - 1);
                        }
                        renderer.DrawText(e.Graphics, rendererBounds, otherLines, false /*drawDisabled*/, TextFormatFlags.Left);
                    }
                }
            }
            else
            {
                // Fall back to non-visual style drawing.
                e.DrawBackground();
                e.DrawBorder();
                using (var sf = new StringFormat())
                {
                    sf.LineAlignment = StringAlignment.Center;
                    e.Graphics.DrawString(e.ToolTipText, SystemFonts.DialogFont, Brushes.Black, e.Bounds, sf);
                }
            }
        }
    }
