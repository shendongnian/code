    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    using System.Diagnostics;
    using WindowsFormsControlLibrary1;
    namespace WindowsFormsApplication1 {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            protected override void OnShown(EventArgs e)
            {
                Controls.Add(new DebugControl());
            }
            protected override void OnControlAdded(ControlEventArgs e)
            {
                base.OnControlAdded(e);
                if (e.Control.GetType() == typeof(DebugControl))
                {
                    int count = 0;
                    foreach (Control c in Controls)
                    {
                        if (c is DebugControl)
                        {
                            count++;
                        }
                    }
                    if (count > 1)
                    {
                        Controls.Remove(e.Control);
                        Debug.Assert(false, "Cannot add two of these controls!");
                    }
                }
            }
        }
    }
