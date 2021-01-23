    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Windows.Forms;
    
    class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        ListView listView;
        List<Unit> units;
        bool insertingItem = false;
    
        public Form1()
        {
            Controls.Add(listView = new ListView
            {
                Dock = DockStyle.Fill,
                View = View.Details,
                CheckBoxes = true,
                Columns = { "Name" },
            });
    
            Controls.Add(new Button { Text = "Add", Dock = DockStyle.Top });
            Controls[1].Click += (s, e) => AddNewItem();
    
            listView.ItemChecked += (s, e) =>
                {
                    Unit unit = e.Item.Tag as Unit;
                    Debug.Write(String.Format("Item '{0}' checked = {1}", unit.Name, unit.OnHold));
                    if (insertingItem)
                    {
                        Debug.Write(" [Ignored]");
                    }
                    else
                    {
                        Debug.Write(String.Format(", setting checked = {0}", e.Item.Checked));
                        unit.OnHold = e.Item.Checked;
                    }
                    Debug.WriteLine("");
                };
    
            units = new List<Unit> { };
        }
    
        Random Rand = new Random();
        int NameIndex = 0;
        readonly string[] Names = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten" };
        void AddNewItem()
        {
            if (NameIndex < Names.Length)
            {
                Unit newUnit = new Unit { Name = Names[NameIndex++], OnHold = Rand.NextDouble() < 0.6 };
                units.Add(newUnit);
                insertingItem = true;
                try
                {
                    listView.Items.Add(new ListViewItem { Text = newUnit.Name, Checked = newUnit.OnHold, Tag = newUnit });
                }
                finally
                {
                    insertingItem = false;
                }
            }
        }
    }
    
    class Unit
    {
        public string Name { get; set; }
        public bool OnHold { get; set; }
    }
