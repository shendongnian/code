            for (int i = 0; i < 10; i++)
            {
                var o = new Outer();
                for (int k = 0; k < 10; k++)
                {
                    o.SubChildren.Add(new Inner() { Name = "ID: "+k });
                }
                Lists.Add(o);
            }
            DynamicGrid.ItemsSource = Lists;
