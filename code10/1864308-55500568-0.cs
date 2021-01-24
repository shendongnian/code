 [XmlRoot("Jobs")]
    public class JobList
    {
        [XmlElement("Job")]
        public string Job { get; set; }
        [XmlElement("JobDate")]
        public string JobDate { get; set; }
        [XmlElement("File")]
        public string File { get; set; }
        [XmlElement("FilePath")]
        public string FilePath { get; set; }
        [XmlElement("Extension")]
        public string Extension { get; set; }
        [XmlElement("Age")]
        public string c { get; set; }
        [XmlElement("JobComment")]
        public string JobComment { get; set; }
    }
    public partial class amgrid : Window
    {
        public amgrid()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            string docPath = @"C:\Users\contract_lshamoon\Desktop\arm\arm\arm\xmldb.xml";
            doc.Load(docPath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList elemList = root.GetElementsByTagName("Jobs");
            findAllNodes(root);
            doc.Save(@"C:\Users\contract_lshamoon\Desktop\arm\arm\arm\xmldb.xml");
        }
        public void findAllNodes(XmlNode node)
        {
            foreach (XmlNode n in node)
            {
                JobList jobs = new JobList();
                string job = n.Attributes["JobId"].Value;
                string date = n.FirstChild.InnerText;
                string file = n.FirstChild.NextSibling.InnerText;
                string path = n.FirstChild.NextSibling.NextSibling.InnerText;
                string extension = n.FirstChild.NextSibling.NextSibling.NextSibling.InnerText;
                string age = n.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                string comment = n.FirstChild.NextSibling.NextSibling.NextSibling.NextSibling.NextSibling.InnerText;
                jobs.Job = job;
                jobs.JobDate = date;
                jobs.File = file;
                jobs.FilePath = path;
                jobs.Extension = extension;
                jobs.c = age;
                jobs.JobComment = comment;
                DG.DataContext = jobs;
                DG.Items.Add(jobs);
            }
        }
    }
        <DataGrid x:Name="DG">
            <DataGrid.DataContext>
                <local:JobList/>
            </DataGrid.DataContext>
            <DataGrid.Columns>
                <DataGridTextColumn x:Name="JobCol" Binding="{Binding Job}" Header="Job"/>
                <DataGridTextColumn x:Name="JobDateCol" Binding="{Binding JobDate}" Header="Date"/>
                <DataGridTextColumn x:Name="FilePathCol" Binding="{Binding FilePath}" Header="Path"/>
                <DataGridTextColumn x:Name="ExtensionCol" Binding="{Binding Extension}" Header="Extension"/>
                <DataGridTextColumn x:Name="AgeCol" Binding="{Binding Age}" Header="Age"/>
                <DataGridTextColumn x:Name="JobCommentCol" Binding="{Binding JobComment}" Header="Comment"/>
            </DataGrid.Columns>
        </DataGrid>
