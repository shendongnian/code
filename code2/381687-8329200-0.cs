    using System;
    using System.IO;
    using System.Xml;
    
    class TemplateParse {
        XmlDocument xdoc;
    
        string GetPath(XmlNode node, string val, string path){
            if(node.HasChildNodes){
                if(node.ChildNodes.Count == 1 && node.FirstChild.NodeType == XmlNodeType.Text)
                    return (node.FirstChild.Value == val) ? path + "/" + node.Name : String.Empty;
                foreach(XmlNode cnode in node.ChildNodes){
                    if(cnode.NodeType != XmlNodeType.Element) continue;
                    string result = GetPath(cnode, val, path + "/" + node.Name);
                    if(result != String.Empty) return result;
                }
            }
            return "";
        }
        public TemplateParse(string templateXml){
            xdoc = new XmlDocument();
            xdoc.LoadXml(templateXml);
        }
        public string Extract(string valName, string data){
            string xpath =  GetPath((XmlNode)xdoc.DocumentElement, "$" + valName, "/");
            var doc = new XmlDocument();
            doc.LoadXml(data);
            return  doc.SelectSingleNode(xpath).InnerText;
    //      var value = doc.SelectSingleNode(xpath).InnerText;
    //      var retType = typeof(T);
    //      return (T)retType.InvokeMember("Parse", System.Reflection.BindingFlags.InvokeMethod, null, null, new []{value});
        }
    }
    
    class Sample {
        static void Main(){
            string templateString = File.ReadAllText(@".\template.xml");
            string incomingString = File.ReadAllText(@".\data.xml");
    
            var p = new TemplateParse(templateString);
            
            string[] names = new [] { "id", "posX", "posY", "posZ" };
            foreach(var name in names){
                var value = p.Extract(name, incomingString);
                Console.WriteLine("{0}:{1}", name, value);
            }
        }
    }
