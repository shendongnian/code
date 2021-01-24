      public partial class MyForm : Form {
        private Dictionary<int, CheckBox> m_CheckBoxTools = new Dictionary<int, CheckBox>();
        public MyForm() {
          InitializeComponent();
          m_CheckBoxTools.Add(1, checkBoxTool1);
          m_CheckBoxTools.Add(3, checkBoxTool3); 
          m_CheckBoxTools.Add(25, checkBoxTool25);
        }
