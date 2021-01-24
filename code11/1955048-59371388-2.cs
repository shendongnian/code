            public Form2()
            {
                InitializeComponent();
                      
                CreateNewUnscrollablePanel();            
            } 
            public void CreateNewUnscrollablePanel()
            {
                var scrollTestForm = new PanelUnScrollable();
                {
                    PanelUnScrollable panel = new PanelUnScrollable() { Dock = DockStyle.Fill };  
                    scrollTestForm.Controls.Add(panel);
                    var buttonOutsideArea = new Button();
                    buttonOutsideArea.Location = new System.Drawing.Point(panel.Width * 2, 100);
                    panel.Controls.Add(buttonOutsideArea);
                    panel.AutoScroll = true;
                    panel.ScrollDisabled = true;-->call the panel propery
                    panel.MouseWheel += delegate(object sender, MouseEventArgs e)
                    {
                        ((HandledMouseEventArgs)e).Handled = true;//--> you dont need this
                    };
                    this.Controls.Add(panel);
                    scrollTestForm.Show();
                }
            }
