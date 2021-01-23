        double xpos = Canvas.GetLeft(curField.assocGrid);
        double ypos = Canvas.GetTop(curField.assocGrid);
        double width = curField.assocGrid.Width;
        double height = curField.assocGrid.Height;
        TextBlock tmp = new TextBlock {
                                          Text = curField.FieldName,
                                          Foreground = new SolidColorBrush(Colors.Red),
                                          HorizontalAlignment = HorizontalAlignment.Center,
                                          VerticalAlignment = VerticalAlignment.Center,
                                          FontSize = 30
                                      };
        Grid grd = new Grid();
        grd.Children.Add(tmp);
        Viewbox vb = new Viewbox();
        vb.Child = grd;
        vb.Width = width;
        vb.Height = height;
        cvsCenterPane.Children.Add(vb);
        Canvas.SetLeft(vb, xpos);
        Canvas.SetTop(vb, ypos);
        curField.scaleViewbox = vb;
        SelectedFields.Add(curField);
