    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Automation;
    public partial class UIAClientApp : Form
    {
        AutomationElement element = null;
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            var dict = new Dictionary<IntPtr, string>();
            foreach(var proc in Process.GetProcesses().Where(p => p.Id > 4 && 
                p.MainWindowHandle != this.Handle && 
                !string.IsNullOrEmpty(p.MainWindowTitle)).ToList())
            {
                dict.Add(proc.MainWindowHandle, proc.MainWindowTitle);
            }
            comboBox1.DisplayMember = "Value";
            comboBox1.ValueMember = "Key";
            comboBox1.DataSource = dict.ToList();
        }
        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            lblCurrentApp.Text = comboBox1.SelectedItem.ToString();
            var window = AutomationElement.FromHandle((IntPtr)comboBox1.SelectedValue);
            if (window != null) {
                GetCommElement(window, ControlType.Edit);
            }
        }
        private void GetCommElement(AutomationElement parent, ControlType controlType)
        {
            element = parent.FindFirst(TreeScope.Subtree, 
                new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));
        }
        private void btnColor_Click(object sender, EventArgs e)
        {
            if (element is null) return;
            var ctrl = sender as Control;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out object pattern)) {
                (pattern as ValuePattern).SetValue(ctrl.Text);
                this.Activate();
            }
        }
    }
