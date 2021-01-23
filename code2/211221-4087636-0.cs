    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication13
    {
       static class Program
       {
          [STAThread]
          static void Main()
          {
             Application.EnableVisualStyles();
             Application.SetCompatibleTextRenderingDefault(false);
             Application.Run(new MainForm());
          }
       }
    
       public class Test
       {
          public string StringProperty { get; set; }
          public int IntProperty { get; set; }
          public bool BoolProperty { get; set; }
       }
    
       class MainForm : Form
       {
          public MainForm()
          {
             var propertyGrid = new PropertyGrid() { Dock = DockStyle.Fill };
             this.Controls.Add(propertyGrid);
             propertyGrid.SelectedObject = new Test();
          }
       }
    }
