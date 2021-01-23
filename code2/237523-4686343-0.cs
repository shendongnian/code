            ContextMenu cm = new ContextMenu();
            for (int i = 0; i < 1000; i++)
            {
                MenuItem mi = new MenuItem();
                mi.Header = "test";
                mi.Tag = this;
                MenuItem sub = new MenuItem { Header = "place holder" };
                mi.Items.Add(sub);
                cm.Items.Add(mi);
                sub.ContextMenuOpening += delegate
                {
                    sub.Items.Clear();
                    for (int j = 0; j < 10; j++)
                    {
                        MenuItem mi2 = new MenuItem();
                        mi2.Header = "test";
                        mi2.Tag = this;
                        mi.Items.Add(mi2);
                    }
                };
            }
            cm.IsOpen = true;
