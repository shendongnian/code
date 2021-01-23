    using System;
    using System.Linq;
    using System.Windows.Forms;
    using System.Xml.Linq;
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                OpenFileDialog OpenFD = new OpenFileDialog();
                OpenFD.InitialDirectory = Application.StartupPath;
                OpenFD.FileName = "";
                OpenFD.ShowDialog();
                if (OpenFD.FileName == "")
                    return;
                textBox1.Text = OpenFD.FileName;
                ReadXMLFile();
            }
            private void ReadXMLFile()
            {
                var X = XDocument.Load(Application.StartupPath + "\\MainList.xml").Descendants("Contact").Select(N => new
            {
                ID = N.Element("ContactID").Value,
                Name=N.Element("Name").Value 
            });
            foreach (var XX in X)
            {
                dataGridView1.Rows.Add(XX.ID, XX.Name);
            }
        }
        private void dataGridView1_RowHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            String St = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            var Data = XDocument.Load(Application.StartupPath + "\\DetailedList.xml").Descendants("Numbers")
                             .Where(X=>X.Element("ContactID").Value ==St)
                             .Select(N => new
                              {
                                  Mobile = N.Element("Mobile").Value,
                                  Office = N.Element("Office").Value,
                                  Home = N.Element("Home").Value
                              });
            dataGridView2.Rows.Clear();
            foreach (var X in Data)
            {
                dataGridView2.Rows.Add(X.Mobile,X.Office,X.Home);
            }
        }
    }
    }
