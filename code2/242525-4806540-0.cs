    using System;
    using System.Data;
    using System.Drawing;
    using System.Windows.Forms;
    using Microsoft.VisualBasic.FileIO;
    
    public class Form1 : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    
        DataTable records;
        BindingSource bindingSource;
    
        public Form1()
        {
            // Create controls
            Controls.Add(new Label { Text = "Name", AutoSize = true, Location = new Point(10, 10) });
            Controls.Add(new TextBox { Name = "Name", Location = new Point(90, 10) });
            Controls.Add(new Label { Text = "Sirname", AutoSize = true, Location = new Point(10, 40) });
            Controls.Add(new TextBox { Name = "Sirname", Location = new Point(90, 40) });
            Controls.Add(new Label { Text = "Birthday", AutoSize = true, Location = new Point(10, 70) });
            Controls.Add(new TextBox { Name = "Birthday", Location = new Point(90, 70) });
            Controls.Add(new Label { Text = "Address", AutoSize = true, Location = new Point(10, 100) });
            Controls.Add(new TextBox { Name = "Address", Location = new Point(90, 100), Size = new Size(180, 30) });
            Controls.Add(new Button { Name = "PrevRecord", Text = "<<", Location = new Point(10, 150) });
            Controls.Add(new Button { Name = "NextRecord", Text = ">>", Location = new Point(150, 150) });
    
            // Load data and create binding source
            records = ReadDataFromFile("Test.csv");
            bindingSource = new BindingSource(records, "");
    
            // Bind controls to data
            Controls["Name"].DataBindings.Add(new Binding("Text", bindingSource, "Name"));
            Controls["Sirname"].DataBindings.Add(new Binding("Text", bindingSource, "Sirname"));
            Controls["Birthday"].DataBindings.Add(new Binding("Text", bindingSource, "Birthday"));
            Controls["Address"].DataBindings.Add(new Binding("Text", bindingSource, "Address"));
    
            // Wire button click events
            Controls["PrevRecord"].Click += (s, e) => bindingSource.Position -= 1;
            Controls["NextRecord"].Click += (s, e) => bindingSource.Position += 1;
        }
    
        DataTable ReadDataFromFile(string path)
        {
            // Create and initialize a data table
            DataTable table = new DataTable();
            table.Columns.Add("Name");
            table.Columns.Add("Sirname");
            table.Columns.Add("Birthday");
            table.Columns.Add("Address");
    
            // Parse CSV into DataTable
            using (TextFieldParser parser = new TextFieldParser(path) { Delimiters = new String[] { ";" } })
            {
                string[] fields;
                while ((fields = parser.ReadFields()) != null)
                {
                    DataRow row = table.NewRow();
                    for (int n = 0; n < fields.Length; n++)
                        row[n] = fields[n];
                    table.Rows.Add(row);
                }
            }
    
            return table;
        }
    }
