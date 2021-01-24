        //two lists for temp storing .xml data
        
        List<Person> list1= new List<Person>();
        List<Person> list2= new List<Person>();
        List<Person> list3= new List<Person>();//for mixing
        string path=@"c:\.....";
        //properties of .xml notes like 'name' and 'payload'
        public class Person
        {
          public string name{ get; set; }//1
          public string payload{ get; set; }//2
        }  
       //load both .xml files saperatly
        void load_list1()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + @"\list1.xml");
            foreach (XmlNode xnode in xdoc.SelectNodes("Items/Item"))
            {
                Person p = new Person();
                p.name= xnode.SelectSingleNode("a").InnerText;
                p.payload= xnode.SelectSingleNode("b").InnerText;
                list1.Items.Add(p);
            }
        }
       
        void load_list2()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + @"\list2.xml");
            foreach (XmlNode xnode in xdoc.SelectNodes("Items/Item"))
            {
                Person p = new Person();
                p.name= xnode.SelectSingleNode("a").InnerText;
                p.payload= xnode.SelectSingleNode("b").InnerText;
                list2.Items.Add(p);
            }
        }
       //start mixing both lists
       void mixdata()
       {
         for(int i=0;i<list1.Items.Count;i++)
         {
           Person p= new Person();
           p.name=list1.Items[i].name;
           p.payload=list2.Items[i].payload;
           list3.Items.Add(p);         
         }
       }
        //saving final mixed list to .xml
        void save()
        {
            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(path + @"\Mixed_data.xml");
            XmlNode xnode = xdoc.SelectSingleNode("Items");
            xnode.RemoveAll();
            foreach (Person i in list3)
            {
                XmlNode xtop = xdoc.CreateElement("Item");
                XmlNode x1 = xdoc.CreateElement("a");
                XmlNode x2 = xdoc.CreateElement("b");
                x1.InnerText = i.name;
                x2.InnerText = i.payload;
                xtop.AppendChild(x1);
                xtop.AppendChild(x2);
                xdoc.DocumentElement.AppendChild(xtop);
            }
            xdoc.Save(path + @"\data.xml");
        }
        //let me know any errors
