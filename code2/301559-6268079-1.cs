       using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public class Item
        {
            public Item(string id,string desc)
            {
                id = id;
                Desc = desc;
            }
            public string Id { get; set; }
            public string Desc { get; set; }
        }
    
        public partial class Form1 : Form
        {
            public const string Searchtext="o";
            public Form1()
            {
                InitializeComponent();
                listBox1.SelectionMode = SelectionMode.MultiExtended;
            }
    
            public static List<Item> GetItems()
            {
                return new List<Item>()
                           {
                               new Item("1","One"),
                               new Item("2","Two"),
                               new Item("3","Three"),
                               new Item("4","Four")
                           };
            }
    
    
            private void Form1_Load(object sender, EventArgs e)
            {
                
                listBox1.DataSource = GetItems();
                listBox1.DisplayMember = "Desc";
                listBox1.ValueMember = "Id";
                listBox1.ClearSelected();
                listBox1.Items.Cast<Item>()
                    .ToList()
                    .Where(x => x.Desc.Contains("o")).ToList()
                    .ForEach(x => listBox1.SetSelected(listBox1.FindString(x.Desc),true));
                
            }
        }
    }
