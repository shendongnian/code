` c-sharp 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.VisualBasic;
namespace ExcelAddInZeroSofts
{
    public partial class InterpolationForm : Form
    {
        Worksheet ws;
        public InterpolationForm(Range rng)
        {
            InitializeComponent();
            tbRange.Text = rng.Address;
        }
        private void SelectRangeForm_Load(object sender, EventArgs e)
        {
            ws = Globals.ThisAddIn.Application.ActiveSheet;
            ws.SelectionChange += ws_SelectionChange;
            // This one will add the event handling to worksheet.
        }
        void ws_SelectionChange(Range Target)
        {
            if (this.ActiveControl.Name.First() == 't')
            {
                this.ActiveControl.Text = Target.Address;
                // This one will add the address to the userform (I have 3 fields).
            }
        }
        private void SelectRangeForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ws.SelectionChange -= ws_SelectionChange;
        }
        private void bSubmit_Click(object sender, EventArgs e)
        {
            // My main Logic Goes here
            this.Close();
        }
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
`
I still hope someone will give the way to have it work like the original VBA inputbox.
