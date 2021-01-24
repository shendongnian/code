static void Main(string[] args)
{
   //
   // your coding here
   //
   Console.ReadLine();
}
It is not a good practice to develop a console application via form application template. Unless to get debug output.
#Editted
If you want to develop a Form app, you have to remove the `Main` method in your form class. The `Main` method is only called once to start the form but you no need to add in your `Form` classes.
#Full Example for Form
Program.cs (Here is where the `Main` method is placed and called only once to start the other form.)
namespace WindowsFormsApp1
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
And now, here is the other form classes.
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
    }
}
Make sure to includes all library needed. This example taken from VS2019 .NET Framework Form Application template.
#Other Occurs
In VS, you can set to start your project with console or not. You can set to in your `Project Properties > Application Tab > Output type` set to `Windows Application`. By default this setting will set to template setting (if form: windows application and if console: console application).
For best practice in form application, use the `debugger console` and set output using `Debug.WriteLine()`.
