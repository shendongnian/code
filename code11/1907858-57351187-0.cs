    using System;
    using System.Drawing;
    using System.Reflection;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp4
    {
        public partial class MdiParent : Form
        {
            private int childIndex;
            private Type MdiControlStrip_SystemMenuItem;
            private Type MdiControlStrip_ControlBoxMenuItem;
            private bool mdiChildControlBoxEnabled = true;
    
            public MdiParent()
            {
                InitializeControls();
                Assembly asm = this.GetType().BaseType.Assembly;
                MdiControlStrip_SystemMenuItem = asm.GetType("System.Windows.Forms.MdiControlStrip+SystemMenuItem");
                MdiControlStrip_ControlBoxMenuItem = asm.GetType("System.Windows.Forms.MdiControlStrip+ControlBoxMenuItem");
            }
    
            private void InitializeControls()
            {
                SuspendLayout();
                Size = new Size(800, 400);
                Text = "MDI Parent";
                IsMdiContainer = true;
                MenuStrip menu = new MenuStrip { Dock = DockStyle.Top };
                ToolStripMenuItem addChild = new ToolStripMenuItem { Text = "Add Child", AutoSize = true };
                addChild.Click += (s, e) => { AddChildForm(); };
                menu.Items.Add(addChild);
    
                ToolStripMenuItem restoreChild = new ToolStripMenuItem { Text = "restore ActiveMdiChild", AutoSize = true };
                restoreChild.Click += (s, e) => { if (ActiveMdiChild != null) ActiveMdiChild.WindowState = FormWindowState.Normal; };
                menu.Items.Add(restoreChild);
    
                ToolStripMenuItem showChildControlBox = new ToolStripMenuItem { Text = "Show Child ControlBox - " + mdiChildControlBoxEnabled.ToString(), AutoSize = true };
                showChildControlBox.Click += (s,e) => {
                    mdiChildControlBoxEnabled = !mdiChildControlBoxEnabled;
                    showChildControlBox.Text = "Show Child ControlBox - " + mdiChildControlBoxEnabled.ToString();
                    SetMDIMenuItemVisiblity(mdiChildControlBoxEnabled);
                };
                menu.Items.Add(showChildControlBox);
    
                Controls.Add(menu);
                MainMenuStrip = menu;
                MainMenuStrip.ItemAdded += MainMenuStrip_ItemAdded;
                ResumeLayout(true);
            }
    
            private void MainMenuStrip_ItemAdded(object sender, ToolStripItemEventArgs e)
            {
                if (!mdiChildControlBoxEnabled)
                {
                    Type itemType = e.Item.GetType();
                    if (itemType == MdiControlStrip_SystemMenuItem || itemType == MdiControlStrip_ControlBoxMenuItem)
                    {
                        e.Item.Visible = false;
                    }
                }
            }
    
            private void SetMDIMenuItemVisiblity(bool visible)
            {
                foreach (ToolStripMenuItem item in MainMenuStrip.Items)
                {
                    Type itemType = item.GetType();
                    if (itemType == MdiControlStrip_SystemMenuItem || itemType == MdiControlStrip_ControlBoxMenuItem)
                    {
                        item.Visible = visible;
                    }
                }
            }
    
            private void AddChildForm()
            {
                childIndex += 1;
                ChildForm cf = new ChildForm();
                cf.Text += childIndex.ToString();
                cf.MdiParent = this;
                cf.Show();
            }
    
            private class ChildForm : Form
            {
                public ChildForm()
                {
                    SuspendLayout();
                    Size = new Size(300, 200);
                    Text = "MDI Child #";
                    BackColor = Color.Bisque;
                    MenuStrip menu = new MenuStrip { Dock = DockStyle.Top };
                    ToolStripMenuItem someItem = new ToolStripMenuItem { Text = "Child Menu Item", AutoSize = true };
                    menu.Items.Add(someItem);
                    menu.Visible = false;
                    Controls.Add(menu);
             
                    ResumeLayout(true);
                }
            }
        }
    }
