    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp
    {
        static class Program
        {
            internal enum StateType
            {
                State1, 
                State2, 
                State3
            }
    
            internal class DemoForm : Form
            {
                ComboBox cmbxType = new ComboBox();
    
                public DemoForm()
                {
                    cmbxType.DataSource = Enum.GetValues(typeof(StateType));
                    Controls.Add(cmbxType);
                }
    
                protected override void OnLoad(EventArgs e)
                {
                    base.OnLoad(e);
                    cmbxType.SelectedItem = StateType.State3;
                }
            }
    
            [STAThread]
            static void Main()
            {
                Application.Run(new DemoForm());
            }
        }
    }
