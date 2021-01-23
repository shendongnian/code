    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Windows.Forms;
    
    class DemoForm : Form
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new DemoForm());
        }
    
        public DemoForm()
        {
            DataTable dataTable = new DataTable { Columns = { "First", "Second", "Third" } };
            dataTable.Rows.Add("This", "Is", "Data");
            dataTable.Rows.Add("Some", "More", "Values");
            DataGridView dgv = new DataGridView
            {
                Dock = DockStyle.Fill,
                DataSource = dataTable,
                RowHeadersVisible = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                ReadOnly = true,
            };
            dgv.DoubleClick += (s, e) =>
                {
                    if (dgv.SelectedRows.Count > 0)
                    {
                        DataRow dataRow = (dgv.SelectedRows[0].DataBoundItem as DataRowView).Row;
                        using (GenericDataRowForm form = new GenericDataRowForm(dataRow))
                        {
                            if (form.ShowDialog(this) == DialogResult.OK)
                            {
                                // TODO: Validate and save data
    
                                // Just showing how to iterate GenericDataRowForm.Items
                                foreach (KeyValuePair<string, string> pair in form.Items)
                                    Trace.WriteLine(String.Format("Column = {0}, Value = {1}", pair.Key, pair.Value));
                            }
                        }
                    }
                };
            Controls.Add(dgv);
        }
    }
    
    class GenericDataRowForm : Form
    {
        public GenericDataRowForm()
        {
        }
        public GenericDataRowForm(DataRow row)
        {
            // Basic dialog box styles
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MinimizeBox = MaximizeBox = ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
    
            // You would probably want to set the caption (this.Text) to
            //  something meaningful from the outside, so left it out here.
    
            // Record the number of items
            itemCount = row.Table.Columns.Count;
    
            // Create a TableLayoutPanel to arrange the Label/TextBox pairs (and the Ok/Cancel buttons).
            TableLayoutPanel panel = new TableLayoutPanel
            {
                Name = "LayoutPanel",
                ColumnCount = 2,
                ColumnStyles = { new ColumnStyle(), new ColumnStyle(SizeType.Percent, 100F) },
                RowCount = itemCount + 1,
                // We will dock it later, but we want to know how big it should be.
                AutoSize = true,
            };
    
            int itemIndex = 0; // Intentionally declared outside as we'll use it for the buttons below.
            for (; itemIndex < itemCount; itemIndex++)
            {
                panel.RowStyles.Add(new RowStyle());
                string columnName = row.Table.Columns[itemIndex].ColumnName;
                panel.Controls.Add(new Label { Text = columnName, AutoSize = true, Anchor = AnchorStyles.Right }, 0, itemIndex);
                // Note that the text box has its Name set to the data column name and it's Text to the value of that column.
                panel.Controls.Add(new TextBox { Name = columnName, Text = row[itemIndex].ToString(), Dock = DockStyle.Fill }, 1, itemIndex);
            }
    
            // Add Ok and Cancel buttons
            panel.RowStyles.Add(new RowStyle());
            panel.Controls.Add(new Button { Text = "Ok", Name = "OkButton", DialogResult = DialogResult.OK }, 0, itemIndex);
            panel.Controls.Add(new Button { Text = "Cancel", Name = "CancelButton", DialogResult = DialogResult.Cancel }, 1, itemIndex);
            AcceptButton = panel.Controls["OkButton"] as IButtonControl;
            CancelButton = panel.Controls["CancelButton"] as IButtonControl;
    
            // Adjust this Form's size to the panel.
            ClientSize = new Size(320, panel.Height + 10);
            // Then dock the panel so that it conforms to the Form.
            panel.Dock = DockStyle.Fill;
    
            Controls.Add(panel);
        }
    
        public int ItemCount
        {
            get { return itemCount; }
        }
    
        // We need some way for the outside world to view the data that
        //  might have been edited by the user. This could be much more
        //  complicated. As a simple example, this allows the consumer
        //  to iterate over each item as a KeyValuePair. The key is the
        //  data column name and the value is the Text field of the TextBox.
        public IEnumerable<KeyValuePair<string, string>> Items
        {
            get
            {
                if (itemCount > 0)
                {
                    TableLayoutPanel panel = Controls["LayoutPanel"] as TableLayoutPanel;
                    foreach (Control control in panel.Controls)
                    {
                        TextBox textBox = control as TextBox;
                        if (textBox != null)
                            yield return new KeyValuePair<string, string>(textBox.Name, textBox.Text);
                    }
                }
            }
        }
    
        private int itemCount = 0;
    }
