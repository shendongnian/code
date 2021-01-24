          private void addParagraph(Paragraph para)
            {
                if (contentCanvas == null)
                {
                    return;
                }
                
                RichTextBlock rtb = new RichTextBlock();
                rtb.Blocks.Add(para);
                rtb.TextWrapping = TextWrapping.Wrap;
                rtb.FontSize = 12;
                rtb.Foreground = new SolidColorBrush(Colors.Black);
                rtb.Width = contentCanvas.Width;
                rtb.Measure(new Size(contentCanvas.Width, Double.PositiveInfinity));
                var size = rtb.DesiredSize;
                rtb.Height = size.Height;
               
    
                double fHeight = rtb.Height;
                double cHeight = contentCanvas.Height;
    
                Debug.WriteLine("y: " + y);
                Debug.WriteLine("cH: " + cHeight);
                Debug.WriteLine("cW: " + contentCanvas.Width);
                Debug.WriteLine("rtb.H: " + fHeight);
    
                if ((y + fHeight) > contentCanvas.Height)
                {
                    // Create a new page
                    createPage();
                }
    
                contentCanvas.Children.Add(rtb);
    
                Canvas.SetLeft(rtb, x);
                Canvas.SetTop(rtb, y);
    
                y += fHeight;
                
    
            }
