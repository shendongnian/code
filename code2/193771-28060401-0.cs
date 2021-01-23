    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Xml;
    namespace MyProject.MyConfigSection
    {
        public class MyConfig:System.Configuration.IConfigurationSectionHandler
        {
            public int MyNum1 { get; set; }
            public int MyNum2 { get; set; }
            public int MyNum3 { get; set; }
        public MyConfig()
        {
            MyNum1 = 0;
            MyNum2 = 0;
            MyNum3 = 0;
        }
    //implement interface member
        public object Create(object parent, object configContext, System.Xml.XmlNode section)
        {
            try
            {
                MyConfig options = new MyConfig();
                if (section == null) return options;
                foreach (XmlNode node in section.ChildNodes)
                {
                    if (node.Name == "MyNum1")
                        options.MyNum1 = int.Parse(node.InnerText);
                    else if (node.Name == "MyNum2")
                        options.MyNum2 = int.Parse(node.InnerText);
                    else if (node.Name == "MyNum3")
                        options.MyNum3 = int.Parse(node.InnerText);
                }
                return options;
            }
            catch (Exception ex)
            {
                throw new System.Configuration.ConfigurationException(
                 "Error loading startup default options", ex, section);
            }
        }
    }
