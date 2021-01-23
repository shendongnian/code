    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
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
            var dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = new List<DummyObject>
                {
                    new DummyObject { Name = "One", Value = 1 },
                    new DummyObject { Name = "Two", Value = 2 },
                    new DummyObject { Name = "Three", Value = 3 },
                }
            };
            dgv.EditingControlShowing += (s, e) => e.Control.VisibleChanged += DgvEditingControlVisibleChanged;
            Controls.Add(dgv);
        }
    
        void DgvEditingControlVisibleChanged(object sender, EventArgs e)
        {
            Control control = sender as Control;
            if (control.Visible)
            {
                // The editing control has become visible.
    
                Trace.WriteLine(String.Format("Editing control showing {0}", control));
            }
            else
            {
                // The editing control has been removed.
    
                // Remove the event handler because the DGV can use multiple
                //  editing controls if it has different column types. 
                control.VisibleChanged -= DgvEditingControlVisibleChanged;
                Trace.WriteLine(String.Format("Editing control removed {0}", control));
            }
        }
    }
    
    public class DummyObject
    {
        public string Name { get; set; }
        public int Value { get; set; }
    }
