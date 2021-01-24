    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> EMPLOYEE_MEMBER_INDIVID_ROLE_DATA_S = doc.Descendants("EMPLOYEE_MEMBER_INDIVID_ROLE_DATA_S").ToList();
                foreach (XElement EMPLOYEE_MEMBER_INDIVID_ROLE_DATA in EMPLOYEE_MEMBER_INDIVID_ROLE_DATA_S)
                {
                    string[] roles = EMPLOYEE_MEMBER_INDIVID_ROLE_DATA.Descendants("EMPLOYEE_MEMBER_INDIVID_ROLE_ON_APPLICATION").Select(x => (string)x).ToArray();
                    XElement newEMPLOYEE_MEMBER_INDIVID_ROLE_DATA = new XElement("EMPLOYEE_MEMBER_INDIVID_ROLE_DATA", new object[] {
                        new XAttribute("ENTITY", ""),
                        new XElement("EMPLOYEE_MEMBER_INDIVID_ROLE_ON_APPLICATION", string.Join(" / ", roles))
                    });
                    EMPLOYEE_MEMBER_INDIVID_ROLE_DATA.ReplaceWith(newEMPLOYEE_MEMBER_INDIVID_ROLE_DATA);
                }
     
            }
        }
     
      
    }
