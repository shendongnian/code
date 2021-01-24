    public partial class Form1 : Form
    {
        UserControl1[] userControls;
        RadScrollablePanel parentPanel;
        Panel spacePanel;
    
        public Form1()
        {
            InitializeComponent();
    
            new Telerik.WinControls.RadControlSpy.RadControlSpyForm().Show();
        }
    
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
                        
            this.parentPanel = new RadScrollablePanel();
            this.parentPanel.Dock = DockStyle.Fill;
    
            this.parentPanel.BackColor = Color.Yellow;
           
            this.Controls.Add(this.parentPanel);
            this.parentPanel.AutoScroll = true;
    
            int count = 10;
            this.userControls = new UserControl1[count];
    
            for (int i = 0; i < count; i++)
            {
                this.userControls[i] =
                    new UserControl1()
                    {
                        Dock = DockStyle.Left,
                        BackColor = Color.FromKnownColor((KnownColor)(i + 50))
                    };
    
                this.parentPanel.Controls.Add(this.userControls[i]);
            }
    
            this.spacePanel = new Panel();
            this.spacePanel.Dock = DockStyle.Left;
            this.parentPanel.Controls.Add(this.spacePanel);
        }
    
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
    
            if (this.spacePanel != null)
            {
                int lastPanelWidth = this.parentPanel.Width;
                foreach (Control control in this.parentPanel.PanelContainer.Controls)
                {
                    if (control.Dock == DockStyle.Left && control != this.spacePanel)
                    {
                        lastPanelWidth -= control.Width;
                    }
                }
    
                if (lastPanelWidth < 0)
                {
                    lastPanelWidth = 0;
                }
    
                this.spacePanel.Width = lastPanelWidth;
            }
        }
    }
