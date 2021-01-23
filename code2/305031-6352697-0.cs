        using System.Data;
        using System.Drawing;
        using System.Linq;
        using System.Text;
        using System.Windows.Forms;
        
        namespace SO_Forms_Demo
        {
            public partial class ComboBoxes : Form
            {
                public ComboBoxes()
                {
                    InitializeComponent();
                }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
                {
                    //do whatever else you want to do here....
        
                    removeDuplicateValues((ComboBox)sender, ((ComboBox)sender).SelectedItem.ToString());
                }
    
    //....Through ...//
                private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
                {
                    //do whatever else you want to do here....
        
                    removeDuplicateValues((ComboBox)sender, ((ComboBox)sender).SelectedItem.ToString());
                }
        
                private void removeDuplicateValues(ComboBox sender, string value)
                {
                    //get all of the comboboxes in a collection
                    List<ComboBox> comboboxes = this.Controls.OfType<ComboBox>().ToList<ComboBox>();
                    foreach (ComboBox cb in comboboxes)
                    {
                        if (cb != sender)
                        {
                            cb.Items.Remove(value);
                        }
                    }
                }
            }
        }
