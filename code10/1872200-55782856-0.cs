    public partial class Form1 : Form
        {
            private const string SNIPPET1 = "Hello world";
            private const string SNIPPET2 = "I love Stack";
            private const string FILENAME = "output.txt";
    
            private string OutputFile
            {
                get
                {
                    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, FILENAME);
                }
            }
    
            public Form1()
            {
                InitializeComponent();
            }
    
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox1.Checked)
                {
                    AddSnippet(SNIPPET1);
                }
                else
                {
                    RemoveSnippet(SNIPPET1);
                }
            }
    
            private void checkBox2_CheckedChanged(object sender, EventArgs e)
            {
                if (checkBox2.Checked)
                {
                    AddSnippet(SNIPPET2);
                }
                else
                {
                    RemoveSnippet(SNIPPET2);
                }
            }
    
            private void AddSnippet(string snippet)
            {
                File.AppendAllText(OutputFile, snippet);
            }
    
            private void RemoveSnippet(string snippet)
            {
                // Read in the file
                var fileContents = File.ReadAllText(OutputFile);
    
                // Remove the snippet by replacing it with a blank string
                fileContents = fileContents.Replace(snippet, String.Empty);
    
                // Write file contents
                File.WriteAllText(OutputFile, fileContents);
            }
        }
