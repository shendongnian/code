    using System;
    using System.Xml;
    using System.Collections.Generic;
    
    class Sample{
        static void Main(string[] args){
            var doc = new XmlDocument();
            doc.LoadXml(@"
                <!DOCTYPE root [
                  <!ELEMENT root (ul*) > 
                  <!ELEMENT ul (li+) > 
                  <!ELEMENT li ANY >
                  <!ATTLIST root id ID #REQUIRED>
                  <!ATTLIST li   id ID #REQUIRED>]>
                <root id='root'></root>");
            var relation = new List<String>(){
                "child.child2.child3",
                "child7",
                "child10.child14.child15",
                "child10.child14.child16"
            };
    /* output(by hand made pretty):
      <ul>
        <li>child<ul><li>child2<ul><li>child3</li></ul></li></ul></li>
        <li>child7</li>
        <li>child10<ul><li>child14<ul><li>child15</li><li>child16</li></ul></li></ul></li>
      </ul>
    */
    /*
            var relation = new List<String>(){
                "child1",
                "child1.child9",
                "child4.child10.child11",
                "child4.child10.child12"
            };
            var relation = new List<String>(){
                "child",
                "child.child1",
                "child.child2",
                "child.child2.child3"
            };
    */
            foreach(var path in relation){
                MakeTree(doc, path);
            }
            DeleteId(doc.DocumentElement);
            string result = doc.DocumentElement.InnerXml;
            Console.WriteLine(result);
    //      doc.Save(Console.Out);
        }
        static void MakeTree(XmlDocument doc, string path){
            string parent = "root";
            foreach(var node in path.Split('.')){
                AppendChild(doc, parent, node);
                parent = node;
            }
        }
        static void DeleteId(XmlElement el){
            el.RemoveAttribute("id");
            if(el.HasChildNodes){
                foreach(XmlNode node in el.ChildNodes){
                    if(node.NodeType == XmlNodeType.Element){
                        DeleteId((XmlElement)node);
                    }
                }
            }
        }
        static void AppendChild(XmlDocument doc, string parent, string child){
            var childElement = doc.GetElementById(child);
            if(childElement == null){
                var li   = doc.CreateElement("li");
                var text = doc.CreateTextNode(child);
                li.SetAttribute("id", child);
                li.AppendChild(text);
                var parentElement = doc.GetElementById(parent);
                if(parent == "root"){
                    if(parentElement.HasChildNodes){
                        parentElement.FirstChild.AppendChild(li);
                    } else {
                        var ul   = doc.CreateElement("ul");
                        ul.AppendChild(li);
                        parentElement.AppendChild(ul);
                    }
                } else {
                    if(parentElement.LastChild.NodeType == XmlNodeType.Text){
                        var ul   = doc.CreateElement("ul");
                        ul.AppendChild(li);
                        parentElement.AppendChild(ul);
                    } else {
                        parentElement.LastChild.AppendChild(li);
                    }
                }
            }
        }
    }
