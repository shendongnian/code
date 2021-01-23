    void Main()
    {
    	TextBox textBox = new TextBox()
        {
            Multiline = true,
            Size = new Size(200, 60),
            Text = @"string x = ""hello"";int myLength;myLength = x.Length;MessageBox.Show(myLength.ToString());"
        };
        Button button = new Button()
        {
            Location = new Point(0, 60)
        };
        button.Click += new EventHandler(delegate(object sender, EventArgs e)
            {
                var csc = new CSharpCodeProvider(new Dictionary<string, string>() { { "CompilerVersion", "v3.5" } });
                var parameters = new CompilerParameters(new[] { "mscorlib.dll", "System.dll", "System.Windows.Forms.dll" }, "foo.exe", true);
                parameters.GenerateExecutable = true;
                CompilerResults results = csc.CompileAssemblyFromSource(parameters,
                @"
                using System.Windows.Forms;
        
                namespace ConsoleApplication
                {
                    class Program
                    {
                        static void Main(string[] args)
                        {
                            " + 
                            textBox.Text 
                            + @"
                        }
                    }
                }
                ");                
                Process proc = Process.Start("foo.exe");
            }
        );
        
    	Form f = new Form
    	{
    		Controls = { textBox, button }
    	};
    	Application.Run(f);
    }
