    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    using System.Xml.Linq;
    namespace WpfApplication
    {
        public class Attributes
        {
            public string Ref { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return Ref + " " + Name;
            }
        }
        public class Section
        {
            public Attributes Attributes { get; set; }
            public List<SubSection> SubSections { get; set; }
        }
        public class SubSection
        {
            public Attributes Attributes { get; set; }
            public List<Item> Items { get; set; }
        }
        public class Item
        {
            public Attributes Attributes { get; set; }
            public string Description { get; set; }
            public string Units { get; set; }
            public string Formula { get; set; }
        }
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                LoadFile();
                DataContext = this;
            }
            public List<Section> Sections
            {
                get;
                private set;
            }
            private void LoadFile()
            {
                XDocument xmlFile = XDocument.Load(@"XMLFile1.xml");
                var q = from section in xmlFile.Descendants("Section")
                        select new Section()
                        {
                            Attributes = new Attributes() 
                            {
                                Ref = section.Attribute("ref").Value,
                                Name = section.Attribute("name").Value 
                            },
                            SubSections = new List<SubSection>(from subsection in section.Descendants("Subsection")
                                          select new SubSection()
                                          {
                                              Attributes = new Attributes()
                                              {
                                                  Ref = subsection.Attribute("ref").Value,
                                                  Name = subsection.Attribute("name").Value
                                              },
                                              Items = new List<Item>(from item in subsection.Descendants("Item")
                                                       select new Item()
                                                       {
                                                           Attributes = new Attributes()
                                                           {
                                                               Ref = item.Attribute("ref").Value,
                                                               Name = item.Attribute("name").Value
                                                           },
                                                           Description = item.Element("Description").Value,
                                                           Formula = item.Element("Formula").Value,
                                                           Units = item.Element("Units").Value
                                                       })
                                          })
                        };
                Sections = new List<Section>(q);
            }
        }
    }
