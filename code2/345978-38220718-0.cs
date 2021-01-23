    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace LastenBoekInfrastructure.Controls.Controls
    {
        [DefaultEvent("Click")]
        public class ImageButton : UserControl
        {
            public string ToolTipText
            {
                get { return _bButton.ToolTipText; }
                set { _bButton.ToolTipText = value; }
            }
    
            public bool CheckOnClick
            {
                get { return _bButton.CheckOnClick; }
                set { _bButton.CheckOnClick = value; }
            }
    
            public bool DoubleClickEnabled
            {
                get { return _bButton.DoubleClickEnabled; }
                set { _bButton.DoubleClickEnabled = value; }
            }
            
            public System.Drawing.Image Image
            {
                get { return _bButton.Image; }
                set { _bButton.Image = value; }
            }
    
            public new event EventHandler Click;
            public new event EventHandler DoubleClick;
    
            private ToolStrip _tsMain;
            private ToolStripButton _bButton;
    
            public ImageButton()
            {
                InitializeComponent();
            }
    
            private void InitializeComponent()
            {
                var resources = new ComponentResourceManager(typeof(ImageButton));
                _tsMain = new ToolStrip();
                _bButton = new ToolStripButton();
                _tsMain.SuspendLayout();
                SuspendLayout();
                
                // 
                // tsMain
                // 
                _tsMain.BackColor = System.Drawing.Color.Transparent;
                _tsMain.CanOverflow = false;
                _tsMain.Dock = DockStyle.Fill;
                _tsMain.GripMargin = new Padding(0);
                _tsMain.GripStyle = ToolStripGripStyle.Hidden;
                _tsMain.Items.AddRange(new ToolStripItem[] {
                _bButton});
                _tsMain.Location = new System.Drawing.Point(0, 0);
                _tsMain.Name = "_tsMain";
                _tsMain.Size = new System.Drawing.Size(25, 25);
                _tsMain.TabIndex = 0;
                _tsMain.Renderer = new ImageButtonToolStripSystemRenderer();
                // 
                // bButton
                // 
                _bButton.DisplayStyle = ToolStripItemDisplayStyle.Image;
                _bButton.Image = ((System.Drawing.Image)(resources.GetObject("_bButton.Image")));
                _bButton.ImageTransparentColor = System.Drawing.Color.Magenta;
                _bButton.Name = "_bButton";
                _bButton.Size = new System.Drawing.Size(23, 22);
                _bButton.Click += bButton_Click;
                _bButton.DoubleClick += bButton_DoubleClick;
                // 
                // ImageButton
                // 
                Controls.Add(_tsMain);
                Name = "ImageButton";
                Size = new System.Drawing.Size(25, 25);
                _tsMain.ResumeLayout(false);
                _tsMain.PerformLayout();
                ResumeLayout(false);
                PerformLayout();
            }
    
            void bButton_Click(object sender, EventArgs e)
            {
                if (Click != null)
                {
                    Click(this, e);
                }
            }
    
            void bButton_DoubleClick(object sender, EventArgs e)
            {
                if(DoubleClick != null)
                {
                    DoubleClick(this, e);
                }
            }
    
            public class ImageButtonToolStripSystemRenderer : ToolStripSystemRenderer
            {
                protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
                {
                    //base.OnRenderToolStripBorder(e);
                }
            }
        }
    }
