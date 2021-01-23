    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace TestDataGridView
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                this.PopulateDataGrid();
            }
    
            private void PopulateDataGrid()
            {
                List<BindID> bindList = new List<BindID>();
                List<ClassA> aList = new List<ClassA>();
                List<ClassB> bList = new List<ClassB>();
    
                for (int i = 0; i < 10; i++)
                {
                   ClassA newClassA = new ClassA() { ID = Guid.NewGuid(), Name = i.ToString() };
                   ClassB newClassB = new ClassB() { ID = Guid.NewGuid(), Name = i.ToString() };
                   BindID newBindID = new BindID() { ID = Guid.NewGuid(), AID = newClassA.ID, BID = newClassB.ID };
    
                   bList.Add(newClassB);
                   aList.Add(newClassA);
                   bindList.Add(newBindID);
                }
    
                bindingSourceA.DataSource = aList;
                ColumnA.ValueMember = "ID";
                ColumnA.DisplayMember = "Name";
    
                bindingSourceB.DataSource = bList;
                ColumnB.ValueMember = "ID";
                ColumnB.DisplayMember = "Name";
    
                bindingSourceBindID.DataSource = bindList;
            }
        }
    
        public class BindID
        {
            public Guid ID { get; set; }
            public Guid AID { get; set; }
            public Guid BID { get; set; }
        }
        public class ClassA
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
        }
        public class ClassB
        {
            public Guid ID { get; set; }
            public string Name { get; set; }
        }
    }
