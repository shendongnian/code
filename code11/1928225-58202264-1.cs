`
    static string UserDataFolderPath
      = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
      + Path.DirectorySeparatorChar
      + AssemblyCompany
      + Path.DirectorySeparatorChar
      + AssemblyTitle
      + Path.DirectorySeparatorChar;
    static string UserDocumentsFolderPath
      = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
      + Path.DirectorySeparatorChar
      + AssemblyCompany
      + Path.DirectorySeparatorChar
      + AssemblyTitle
      + Path.DirectorySeparatorChar;
`
And these methods:
`
    static public string AssemblyCompany
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly()
                              .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
        if ( attributes.Length == 0 )
        {
          return "";
        }
        return ( (AssemblyCompanyAttribute)attributes[0] ).Company;
      }
    }
    static public string AssemblyTitle
    {
      get
      {
        object[] attributes = Assembly.GetExecutingAssembly()
                              .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
        if ( attributes.Length > 0 )
        {
          AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
          if ( titleAttribute.Title != "" )
          {
            return titleAttribute.Title;
          }
        }
        return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
      }
    }
`
Add at the beginning of the `Main` method:
    Directory.CreateDirectory(UserDataFolderPath);
    Directory.CreateDirectory(UserDocumentsFolderPath);
    if ( Properties.Settings.Default.LastPath == "" )
    {
      Properties.Settings.Default.LastPath = UserDataFolderPath;
      Properties.Settings.Default.Save();
    }
Now to get it you can write in the `FormLoad` event of your form:
    textBox1.Text = Properties.Settings.Default.LastPath;
Put in the `FormClosed` event:
    Properties.Settings.Default.LastPath = textBox1.Text;
    Properties.Settings.Default.Save();
Here what should be your `Program.cs`:
    using System;
    using System.IO;
    using System.Reflection;
    using System.Windows.Forms;
    namespace WindowsFormsAppTest
    {
      static class Program
      {
        [STAThread]
        static void Main()
        {
          Directory.CreateDirectory(UserDataFolderPath);
          Directory.CreateDirectory(UserDocumentsFolderPath);
          if ( Properties.Settings.Default.LastPath == "" )
          {
            Properties.Settings.Default.LastPath = UserDataFolderPath;
            Properties.Settings.Default.Save();
          }
          Application.EnableVisualStyles();
          Application.SetCompatibleTextRenderingDefault(false);
          Application.Run(new FormTest());
        }
        static string UserDataFolderPath
          = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)
          + Path.DirectorySeparatorChar
          + AssemblyCompany
          + Path.DirectorySeparatorChar
          + AssemblyTitle
          + Path.DirectorySeparatorChar;
        static string UserDocumentsFolderPath
          = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
          + Path.DirectorySeparatorChar
          + AssemblyCompany
          + Path.DirectorySeparatorChar
          + AssemblyTitle
          + Path.DirectorySeparatorChar;
        static public string AssemblyCompany
        {
          get
          {
            object[] attributes = Assembly.GetExecutingAssembly()
                                  .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
            if ( attributes.Length == 0 )
            {
              return "";
            }
            return ( (AssemblyCompanyAttribute)attributes[0] ).Company;
          }
        }
        static public string AssemblyTitle
        {
          get
          {
            object[] attributes = Assembly.GetExecutingAssembly()
                                  .GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
            if ( attributes.Length > 0 )
            {
              AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
              if ( titleAttribute.Title != "" )
              {
                return titleAttribute.Title;
              }
            }
            return Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
          }
        }
      }
    }
And your `Form.cs`:
    using System;
    using System.Windows.Forms;
    namespace WindowsFormsAppTest
    {
      public partial class FormTest : Form
      {
        public FormTest()
        {
          InitializeComponent();
        }
        private void FormTest_Load(object sender, EventArgs e)
        {
          textBox1.Text = Properties.Settings.Default.LastPath;
        }
        private void FormTest_FormClosed(object sender, FormClosedEventArgs e)
        {
          Properties.Settings.Default.LastPath = textBox1.Text;
          Properties.Settings.Default.Save();
        }
      }
    }
