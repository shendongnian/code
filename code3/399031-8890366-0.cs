                Span nick = new Span();
                nick.Foreground = Brushes.Blue;
                Span date = new Span();
                date.FontWeight = FontWeights.Bold;
    
                Paragraph para = new Paragraph();
                para.Inlines.Add(nick);
                para.Inlines.Add(date);
                FlowDocument d = new FlowDocument();
                d.Blocks.Add(para);
                rtb.Document = d;
