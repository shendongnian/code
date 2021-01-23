    using System;
    using System.ComponentModel;
    using System.Drawing.Design;
    using System.Windows.Forms;
    using System.Windows.Forms.Design;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using(var frm = new Form { Controls = { new PropertyGrid {
                Dock = DockStyle.Fill, SelectedObject = new Foo { Bar = "abc"}}}})
            {
                Application.Run(frm);
            }
        }
    }
    class Foo
    {
        [Editor(typeof(FancyStringEditor), typeof(UITypeEditor))]
        public string Bar { get; set; }
    }
    class FancyStringEditor : UITypeEditor
    {
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            var svc = (IWindowsFormsEditorService)provider.GetService(typeof(IWindowsFormsEditorService));
            if (svc != null)
            {
                using (var frm = new Form { Text = "Your editor here"})
                using (var txt = new TextBox {  Text = (string)value, Dock = DockStyle.Fill, Multiline = true })
                using (var ok = new Button { Text = "OK", Dock = DockStyle.Bottom })
                {
                    frm.Controls.Add(txt);
                    frm.Controls.Add(ok);
                    frm.AcceptButton = ok;
                    ok.DialogResult = DialogResult.OK;
                    if (svc.ShowDialog(frm) == DialogResult.OK)
                    {
                        value = txt.Text;
                    }
                }
            }
            return value;
        }
    }
