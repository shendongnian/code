    public partial class MainForm : Form
    {
      static public readonly MainForm Instance;
      static MainForm()
      {
        Instance = new MainForm();
      }
