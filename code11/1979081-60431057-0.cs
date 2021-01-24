    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    namespace WindowsFormsApplication62
    {
        public partial class Form1 : Form
        {
            static DataTable dt = new DataTable();
            const int NUMBER_OF_BUTTON_COLUMNS = 6;
            const int BUTTON_HEIGHT = 50;
            const int BUTTON_WIDTH = 50;
            const int BUTTON_MARGIN = 50;
            
            public Form1()
            {
                InitializeComponent();
                for (int i = 0; i < 20; i++)
                {
                    dt.Columns.Add("Col_" + i.ToString(), typeof(string));
                }
                AddButtons();
            }
            public void AddButtons()
            {
                String[] columnNames = dt.Columns.Cast<DataColumn>().Select(x => x.ColumnName).ToArray();
                for(int i = 0; i < columnNames.Length; i++)
                {
                    Button button = new Button();
                    button.Text = columnNames[i];
                    int column = i % NUMBER_OF_BUTTON_COLUMNS;
                    int row = i / NUMBER_OF_BUTTON_COLUMNS;
                    button.Left = column * (BUTTON_MARGIN + BUTTON_WIDTH);
                    button.Top = row * (BUTTON_MARGIN + BUTTON_HEIGHT);
                    button.Width = BUTTON_WIDTH;
                    button.Height = BUTTON_HEIGHT;
                    this.Controls.Add(button);
                    button.Click +=new EventHandler(Button_Click);
                }
            }
            public void Button_Click(object sender, EventArgs e)
            {
                Button button = sender as Button;
                string buttonName = button.Text;
            }
     
        }
    }
