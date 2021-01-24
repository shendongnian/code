    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace dgvAlphaNumbericSplit
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                dataGridView1.Rows.Clear();
    
                dataGridView1.Rows.Add("abc12", "", "");
                dataGridView1.Rows.Add("def", "", "");
                dataGridView1.Rows.Add("56", "", "");
                dataGridView1.Rows.Add("jkl78", "", "");
                dataGridView1.Rows.Add("mno90", "", "");
            }
    
            private void Button1_Click(object sender, EventArgs e)
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if(dataGridView1.Rows[row.Index].Cells[0].Value != null)
                    {
                        string str = dataGridView1.Rows[row.Index].Cells[0].Value.ToString();
    
                        int index = str.IndexOfAny(new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' });
    
                        string chars = "";
                        string nums = "";
    
                        if (index >= 0)
                        {
                            chars = str.Substring(0, index);
    
                            nums = str.Substring(index);
                        }
                        else
                        {
                            chars = str;
                        }
    
                        dataGridView1.Rows[row.Index].Cells[1].Value = chars;
                        dataGridView1.Rows[row.Index].Cells[2].Value = nums;
    
                    }
                }
            }
        }
    }
