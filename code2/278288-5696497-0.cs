    using System;
    using System.Windows.Forms;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        public Form1()
        {
            ContextMenuStrip = new ContextMenuStrip
            {
                Items =
                {
                    new ToolStripMenuItem
                    {
                        Text = "One",
                        DropDownItems =
                        {
                            new ToolStripMenuItem { Text = "One.1" },
                            new ToolStripMenuItem { Text = "One.2" },
                            new ToolStripMenuItem { Text = "One.3" },
                            new ToolStripMenuItem { Text = "One.4" },
                        },
                    },
                    new ToolStripMenuItem
                    {
                        Text = "Two",
                    },
                    new ToolStripMenuItem
                    {
                        Text = "Three",
                        DropDownItems =
                        {
                            new ToolStripMenuItem { Text = "Three.1" },
                            new ToolStripMenuItem { Text = "Three.2" },
                        },
                    },
                }
            };
    
            foreach (ToolStripMenuItem item in ContextMenuStrip.Items)
                Subscribe(item, ContextMenu_Click);
        }
    
        private static void Subscribe(ToolStripMenuItem item, EventHandler eventHandler)
        {
            // If leaf, add click handler
            if (item.DropDownItems.Count == 0)
                item.Click += eventHandler;
            // Otherwise recursively subscribe
            else foreach (ToolStripMenuItem subItem in item.DropDownItems)
                Subscribe(subItem, eventHandler);
        }
    
        void ContextMenu_Click(object sender, EventArgs e)
        {
            MessageBox.Show((sender as ToolStripMenuItem).Text, "The button clicked is:");
        }
    }
