    using System;
    using System.Drawing;
    using System.Collections;
    using System.Windows.Forms;
    
    namespace Students2
    {
        public partial class Form1 : Form
        {
            public class Student : ListViewItem
            { 
                public Student(string name, float grade) : base()
                {
                    this.Text = name;
                    //Add its grade as a subitem automatically.
                    this.SubItems.Add(new ListViewSubItem(this, grade.ToString()));
                }
            }
    
            public class ListViewItemComparer : IComparer
            {
                private int ColIdx = 0;
                public ListViewItemComparer(int index) { ColIdx = index; }
                public int Compare(object x, object y) 
                { 
                    switch(ColIdx)
                    {              
                        case 1: //Numeric
                            {
                                var a1 = Convert.ToSingle(((ListViewItem)x).SubItems[ColIdx].Text);
                                var a2 = Convert.ToSingle(((ListViewItem)y).SubItems[ColIdx].Text);
                                return a1.CompareTo(a2);
                            }
                        default:
                            return String.Compare(((ListViewItem)x).SubItems[ColIdx].Text, ((ListViewItem)y).SubItems[ColIdx].Text);
                    }              
                }
            }
    
            public Form1()
            {
                InitializeComponent();
    
                //Initialize ctrls
                TextBox txtUsername = new TextBox();
                TextBox txtGrade = new TextBox();
                Button btnAdd = new Button();
                ListView lBox = new ListView();
    
                //POS
                txtUsername.Location = new Point(0, 10);
                txtGrade.Location = new Point(0, 40);
                btnAdd.Location = new Point(0, 80);           
                lBox.Location = new Point(120, 0);
    
                //ListView props
                lBox.HeaderStyle = ColumnHeaderStyle.Clickable;
                lBox.View = View.Details;
                lBox.Size = new Size(200, 200);
                
                //Modify the whole LView sorting so both are synced.
                lBox.ColumnClick += new ColumnClickEventHandler((o, e) =>
                {
                    lBox.ListViewItemSorter = new ListViewItemComparer(e.Column);
                });
    
                lBox.Columns.Add("Name");
                lBox.Columns.Add("Grade");
    
                this.Controls.Add(txtUsername);
                this.Controls.Add(txtGrade);
                this.Controls.Add(btnAdd);
                this.Controls.Add(lBox);
    
                btnAdd.Text = "Add";
    
                //Add a new Student object upon click (Inherits from ListViewItem)
                btnAdd.Click += new EventHandler((o, e) =>
                {
                    try
                    {
                        lBox.Items.Add(new Student(txtUsername.Text, Convert.ToSingle(txtGrade.Text)));
                        lBox.Refresh();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Incorrect input.");
                    }
                });
    
            }
        }
    }
