    using System;
    using System.Windows.Forms;
    using System.Xml;
    
    public class XmlTreeDisplay : System.Windows.Forms.Form{
        private System.Windows.Forms.TreeView treeXml = new TreeView();
    
        public XmlTreeDisplay() {
            treeXml.Nodes.Clear();
            this.Controls.Add(treeXml);
            // Load the XML Document
            XmlDocument doc = new XmlDocument();
            string filePath = @"C:\Documents and Settings\Administrator\Desktop\M.xsd";
            try {
                doc.Load(filePath);
            }catch (Exception err) {
    
                MessageBox.Show(err.Message);
                return;
            }
    
            ConvertXmlNodeToTreeNode(doc, treeXml.Nodes);
            treeXml.Nodes[0].ExpandAll();
        }
    
        private void ConvertXmlNodeToTreeNode(XmlNode xmlNode, 
          TreeNodeCollection treeNodes) {
    
            TreeNode newTreeNode = treeNodes.Add(xmlNode.Name);
    
            switch (xmlNode.NodeType) {
                case XmlNodeType.ProcessingInstruction:
                case XmlNodeType.XmlDeclaration:
                    newTreeNode.Text = "<?" + xmlNode.Name + " " + 
                      xmlNode.Value + "?>";
                    break;
                case XmlNodeType.Element:
                    newTreeNode.Text = "<" + xmlNode.Name + ">";
                    break;
                case XmlNodeType.Attribute:
                    newTreeNode.Text = "ATTRIBUTE: " + xmlNode.Name;
                    break;
                case XmlNodeType.Text:
                case XmlNodeType.CDATA:
                    newTreeNode.Text = xmlNode.Value;
                    break;
                case XmlNodeType.Comment:
                    newTreeNode.Text = "<!--" + xmlNode.Value + "-->";
                    break;
            }
    
            if (xmlNode.Attributes != null) {
                foreach (XmlAttribute attribute in xmlNode.Attributes) {
                    ConvertXmlNodeToTreeNode(attribute, newTreeNode.Nodes);
                }
            }
            foreach (XmlNode childNode in xmlNode.ChildNodes) {
                ConvertXmlNodeToTreeNode(childNode, newTreeNode.Nodes);
            }
        }
        public static void Main(){
           Application.Run(new XmlTreeDisplay());
        }
    }
