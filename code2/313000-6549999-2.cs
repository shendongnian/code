    using System;
    using System.Linq;
    using System.Reflection;
    using System.Windows.Forms;
    using SimplePluginShared;
    namespace SimplePluginHost
    {
        public partial class MainForm : Form
        {
            public MainForm()
            {
                InitializeComponent();
            }
            private void btnBrowse_Click(Object sender, EventArgs e)
            {
                OpenFileDialog openPluginDlg = new OpenFileDialog() { DefaultExt = "dll", Multiselect = false, Title = "Open Plugin DLL", Filter = "DLLs|*.dll" };
                if (openPluginDlg.ShowDialog() == DialogResult.OK)
                {
                    txtPluginPath.Text = openPluginDlg.FileName;
                }
            }
            private void btnGo_Click(Object sender, EventArgs e)
            {
                Assembly pluginDll = Assembly.LoadFrom(txtPluginPath.Text);
                Type pluginType = pluginDll.GetTypes().Where(t => typeof(PluginBase).IsAssignableFrom(t)).First();
                PluginBase pluginInstance = (PluginBase)Activator.CreateInstance(pluginType);
                pluginInstance.ShowDialog();
                MessageBox.Show(pluginInstance.GetStatus());
            }
        }
    }
