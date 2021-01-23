    using System;
    using System.Collections.Generic;
    using System.Xml;
    
    public class XmlClass
    { 
        private XmlDocument _xmlDoc;
        private List<ChildClass> _children As New List<ChildClass>();
    
        public XmlClass(FileInfo fil){
            _xmlDoc = New XmlDocument();
            _xmlDoc.Load(fil.FullName);
    
            ParseChildren();
    
            _xmlDoc = Nothing;
        }
    
        private void ParseChildren(){
            XmlNodeList ndl = _xmlDoc.SelectNodes("/root/t") //select all <t>s
            foreach (xmlNode nodT in ndl.Nodes){
                foreach (xmlNode nodChild in nodT.ChildNodes()){
                    _children.Add(new ChildClass(nodChild));
                }
            }
            // Now _children contains all child nodes of <t>s and can be worked with logically
        }
        public int numberOfChildren
        {
            get {return _children.Count();}
        }
    }
