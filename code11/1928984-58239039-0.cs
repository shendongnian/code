    namespace ClassApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var p = new Plugins();
    
                var types = AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => a.GetTypes()).Where(a => a.ToString().StartsWith("ClassP") || a.ToString().StartsWith("ClassL")).ToArray();
    
                var type = p.GetType();
                var dcs = new DataContractSerializer(type, types);
    
                var settings = new XmlWriterSettings()
                {
                    Indent = true,
                    IndentChars = "    "
                };
    
                using (XmlWriter wr = XmlWriter.Create(@"j:\message.xml", settings))
                {
                    dcs.WriteObject(wr,  p);
                }
    
            }
        }
    }
