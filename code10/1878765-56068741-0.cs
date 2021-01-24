using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1() { InitializeComponent();}
        class WrapperAutoSave
        {
            private bool _IsAutoSaveEnabled;
            [RefreshProperties(System.ComponentModel.RefreshProperties.All)] //// MISTAKE 1 : You missed refresh attribute!
            [DisplayName("Use Autosave ?")]
            public bool IsAutoSaveEnabled
            {
                get { return _IsAutoSaveEnabled; }
                set
                {
                    _IsAutoSaveEnabled = value;
                    PropertyDescriptor descriptor = 
                    TypeDescriptor.GetProperties(this.GetType())["Autosave_Duration"];
                    ReadOnlyAttribute attribute = (ReadOnlyAttribute)
                                                  descriptor.Attributes[typeof(ReadOnlyAttribute)];
                    FieldInfo fieldToChange = attribute.GetType().GetField("isReadOnly",
                                                     BindingFlags.NonPublic |
                                                     BindingFlags.Instance);
                    fieldToChange.SetValue(attribute, _IsAutoSaveEnabled == false);
                }
            }
            [DisplayName("Auto Save Duration")]
            [ReadOnly(true)] //// MISTAKE 2 : You missed read-only attribute
            public int Autosave_Duration { get; set; }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
           propertyGrid1.SelectedObject = new WrapperAutoSave();
        }
    }
}
**Mistake 1 :** You missed important attribute of refreshing. `[RefreshProperties(...)]`
**Mistake 2 :** You missed readonly attribute too and that's why wrong properties are going disabled : ` [ReadOnly(true)]`
