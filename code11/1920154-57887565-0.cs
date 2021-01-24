    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace DgvMultiplyTest
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void CalculateAnswer()
            {
                int dgvRow = dataGridView1.CurrentCell.RowIndex;
                int dgvColumn = dataGridView1.CurrentCell.ColumnIndex;
                int firstNumber = 0;
                int secondNumber = 0;
                int answer = 0;
    
    
                if (dataGridView1.Rows[dgvRow].Cells[0].EditedFormattedValue != null &&
                   dataGridView1.Rows[dgvRow].Cells[1].EditedFormattedValue != null)
                {
                    if ((int.TryParse(dataGridView1.Rows[dgvRow].Cells[0].EditedFormattedValue.ToString(), out firstNumber) == true) &&
                         (int.TryParse(dataGridView1.Rows[dgvRow].Cells[1].EditedFormattedValue.ToString(), out secondNumber) == true))
                    {
                        answer = firstNumber * secondNumber;
                        dataGridView1.Rows[dgvRow].Cells[2].Value = answer;
                    }
                }
            }
    
            private void DataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
            {
                e.Control.KeyUp -= new KeyEventHandler(Control_KeyUp);
                e.Control.KeyUp += new KeyEventHandler(Control_KeyUp);
            }
    
            private void Control_KeyUp(object sender, KeyEventArgs e)
            {
                CalculateAnswer();
                dataGridView1.Invalidate();
            }
        }
    }
