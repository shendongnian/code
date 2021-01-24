    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication4
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                openFileDialog1.ShowDialog();
                txtFile.Text = openFileDialog1.FileName;
                BindData(txtFile.Text);
            }
    
            private void BindData(string filePath)
            {
                DataTable dt = new DataTable();
                string[] lines = System.IO.File.ReadAllLines(filePath);
                if (lines.Length > 0)
                {
                    //first line to create header
                    string firstLine = lines[0];
                    string[] headerLabels = firstLine.Split(',');
                    foreach (string headerWord in headerLabels)
                    {
                        dt.Columns.Add(new DataColumn(headerWord));
                    }
                    //For Data
                    for (int i = 1; i < lines.Length; i++)
                    {
                        string[] dataWords = lines[i].Split(',');
                        DataRow dr = dt.NewRow();
                        int columnIndex = 0;
                        foreach (string headerWord in headerLabels)
                        {
                            dr[headerWord] = dataWords[columnIndex++];
                        }
                        dt.Rows.Add(dr);
                    }
                }
                if (dt.Rows.Count > 0)
                {
                    dataGridView1.DataSource = dt;
                }
            }
    
            private void button2_Click(object sender, EventArgs e)
            {
                try
                {
                    //Build the CSV file data as a Comma separated string.
                    string csv = string.Empty;
    
                    //Add the Header row for CSV file.
                    foreach (DataGridViewColumn column in dataGridView1.Columns)
                    {
                        csv += column.HeaderText + ',';
                    }
                    //Add new line.
                    csv += "\r\n";
    
                    //Adding the Rows
    
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (cell.Value != null)
                            {
                                //Add the Data rows.
                                csv += cell.Value.ToString().TrimEnd(',').Replace(",", ";") + ',';
                            }
                            // break;
                        }
                        //Add new line.
                        csv += "\r\n";
                    }
    
                    //Exporting to CSV.
                    string folderPath = "C:\\Users\\Excel\\Desktop\\";
                    if (!Directory.Exists(folderPath))
                    {
                        Directory.CreateDirectory(folderPath);
                    }
                    File.WriteAllText(folderPath + "test.csv", csv);
                    MessageBox.Show("");
                }
                catch
                {
                    MessageBox.Show("");
                }
            }
        }
    }
