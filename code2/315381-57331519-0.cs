    public int SelectedTab
            {
                get => selected_tab;
                set
                {
                    selected_tab = value;
                    
                    new Task(async () =>
                    {
                        await newTab.ScaleTo(0.8);
                    }).Start();
                }
            }
