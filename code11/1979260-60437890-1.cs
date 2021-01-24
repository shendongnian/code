var xdoc = XDocument.Parse(xml);
// Unclear how you are identifying the node after which the change has to happen. For sake of example, using ID
var selectedNode = xdoc.Descendants("Person")
                       .First(x=>Convert.ToInt32(x.Element("ID").Value)==1000);
// Collection of nodes that would be added as child of newly inserted node
var nodeAfterSelectedNode = xdoc.Descendants("Person")
                                .SkipWhile(x=>x==selectedNode) 
                                .ToList();
// Create the new node with previously identified 'nodeAfterSelectedNode' as Children
var newElement = new XElement("RefNode",nodeAfterSelectedNode);
	
// Remove the existing Nodes (ones that are being moved to child) 
foreach(var node in nodeAfterSelectedNode)
{
   node.Remove();
}
// add the new node 
selectedNode.AddAfterSelf(newElement);
var newXml = xdoc.ToString();
Output
<Employees>
  <Person>
    <ID>1000</ID>
    <Name>Nima</Name>
    <LName>Agha</LName>
  </Person>
  <RefNode>
    <Person>
      <ID>1002</ID>
      <Name>Ligha</Name>
      <LName>Ligha</LName>
    </Person>
    <Person>
      <ID>1003</ID>
      <Name>Jigha</Name>
      <LName>Jigha</LName>
    </Person>
  </RefNode>
</Employees>
Output Sample
