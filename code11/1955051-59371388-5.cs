            public Form2()
            {
                InitializeComponent();
                      
                CreateNewUnscrollablePanel();            
            } 
            public void CreateNewUnscrollablePanel()
            {
               using (var unScrollablePanel = new UnScrollablePanel() { Dock = DockStyle.Fill })
                {                     
                    this.Controls.Add(unScrollablePanel);
                    var buttonOutsideArea = new Button();
                    buttonOutsideArea.Location = new System.Drawing.Point(unScrollablePanel.Width * 2, 100);
                    unScrollablePanel.Controls.Add(buttonOutsideArea);
                    unScrollablePanel.AutoScroll = true;
                    unScrollablePanel.ScrollDisabled = true; //-->call the panel propery
                    unScrollablePanel.MouseWheel += delegate(object sender, MouseEventArgs e) //--> you dont need this
                    {
                        ((HandledMouseEventArgs)e).Handled = true;
                    };
                    
                    this.ShowDialog();
                }
            }
