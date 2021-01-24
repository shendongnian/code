    public partial class MyForm : Form {
      private Dictionary<Label, TextBox> m_Correspondence = 
        new Dictionary<Label, TextBox>();
      public MyForm() {
        InitializeComponent();
        m_Correspondence.Add(lablCinnamonset, textBox1);
        m_Correspondence.Add(lablMallardset, textBox2);
        ...
        m_Correspondence.Add(lablMooseSet, textBox15);
      }
    
    
