           GridView gv = new GridView();
            int i = 0;
            foreach (string s in vm.DateList)
            {
                string column = string.Format("DisplayTime[{0}].Hours", i);
                DataTemplate dt = new DataTemplate();
                DateTime date = DateTime.Parse(s);
                bool isWeekday = true;
                if (date.DayOfWeek == DayOfWeek.Saturday || date.DayOfWeek == DayOfWeek.Sunday)
                {
                    isWeekday = false;
                }
                Binding binding = new Binding();
                binding.Path = new PropertyPath(column);
                binding.Mode = BindingMode.TwoWay;
                FrameworkElementFactory gridElement = new FrameworkElementFactory(typeof(Grid));
                gridElement.SetValue(Grid.WidthProperty, 60.0);
                gridElement.SetValue(Grid.HeightProperty, 94.0);
                gridElement.SetValue(Grid.MarginProperty, new Thickness(0.0, 0.0, 0.0, 4.0));
                if (!isWeekday)
                {
                    gridElement.SetValue(Grid.BackgroundProperty, new SolidColorBrush(Color.FromRgb(65, 65, 65)));
                }
                FrameworkElementFactory txtelement = new FrameworkElementFactory(typeof(TextBox));
                txtelement.SetBinding(TextBox.TextProperty, binding);
                txtelement.SetValue(TextBox.WidthProperty, 40.0);
                txtelement.SetValue(TextBox.HeightProperty, 20.0);
                txtelement.SetValue(TextBox.VerticalAlignmentProperty, VerticalAlignment.Center);
                txtelement.SetValue(TextBox.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                txtelement.SetValue(TextBox.TextAlignmentProperty, TextAlignment.Right);
                gridElement.AppendChild(txtelement);
                dt.VisualTree = gridElement;
                gv.Columns.Add(new GridViewColumn()
                {
                    Header = s,
                    //                            DisplayMemberBinding = new Binding(column),
                    CellTemplate = dt
                });
                i++;
            }
            ETCListView.View = gv;
