    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;
    using System.IO;
    using System.Diagnostics;
    using WMPLib;
    using AxWMPLib;
    
    namespace YourApplicationNamespace
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
                // 40 is the height of the control bar... 320 x 180 is 16:9 aspect ratio
                Panel container = new Panel()
                {
                    Parent = this,
                    Width = 320,
                    Height = 180 + 40,
                    AllowDrop = true,
                    Left = (this.Width - 320) / 2,
                    Top = (this.Height - 180 - 40) / 2,
                };
                AxWindowsMediaPlayer player = new AxWindowsMediaPlayer()
                {
                    AllowDrop = false,
                    Dock = DockStyle.Fill,
                };
                container.Controls.Add(player);
                container.DragEnter += (s, e) =>
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                        e.Effect = DragDropEffects.Copy;
                };
                container.DragDrop += (s, e) =>
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    {
                        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                        var file = files.FirstOrDefault();
                        if (!string.IsNullOrWhiteSpace(file))
                            player.URL = file;
                    }
                };
            }
        }
    }  
