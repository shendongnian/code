    using System;
    using System.Drawing;
    using System.Windows.Forms;
    
    namespace Tools.Tester
    {
        class Stackoverflow
        {
            public static void QuestionCaptureFunctionalKeys()
            {
                Form form = new Form();
    
                //CREATE TABLE
                DataGridView table = new CustomTable();
                table.Location = new Point(40, 40);
                table.Columns.Add("Column 1", "Column 1");
                table.Rows.Add();
                form.Controls.Add(table);
    
                //ADD EVENT LISTENER
                form.ShowDialog();
            }
    
            class CustomTable : DataGridView
            {
                protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
                {
                    if ((keyData == Keys.Enter) && (EditingControl != null))
                    {
                        Console.WriteLine("ProcessCmdKey: " + keyData);
                        return true;
                    }
                    //for the rest of the keys, proceed as normal
                    return base.ProcessCmdKey(ref msg, keyData);
                }
            }
        }
    }
