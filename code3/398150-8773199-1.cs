        docFlowDocument = new FlowDocument();           
        System.Windows.Media.Brush defaultBrush = System.Windows.Media.Brushes.White;
        docFlowDocument.Background = defaultBrush;
        System.Windows.Media.Brush curBrush = defaultBrush;
        Paragraph p = new Paragraph();
        Run r = new Run();
        r.Background = curBrush;
        #region nullDocument
        if (String.IsNullOrEmpty(DocText))
        {
            r.Foreground = System.Windows.Media.Brushes.Red;
            r.Text = "No Text";
            p.Inlines.Add(r);
            docFlowDocument.Blocks.Add(p);
                        
            List<string> colorNames = (from pc in typeof(Brushes).GetProperties()
                                        select pc.Name).ToList();
            //Debug.WriteLine(colorNames.Count.ToString());
            //Debug.WriteLine(colorNames[0]);
            Type brushesType = typeof(Brushes);
            System.Reflection.MemberInfo[] membersinfo = brushesType.GetMembers();
            System.Reflection.PropertyInfo[] properties = brushesType.GetProperties();
            for (int i = 0; i < properties.Length; i++)
            {
                r = new Run();
                r.Background = (Brush)properties[i].GetValue(null, null);
                r.Text = colorNames[i];
                p.Inlines.Add(r);
                p.Inlines.Add(new LineBreak());
            }
            docFlowDocument.Blocks.Add(p);
            docFlowDocumentFinishedLastRun = true;
            return docFlowDocument;
        }
        #endregion // nullDocument
