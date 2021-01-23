The attribute name is <b>not</b> message name, it is name
foreach (XmlNode item in node.ChildNodes)
{
   paramCollection[j] = item.Attributes["name"].Value;
   Console.WriteLine(paramCollection[j]);
   j++;
}
