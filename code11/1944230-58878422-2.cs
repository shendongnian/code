var input = @"<?xml version=""1.0"" encoding=""utf-8""?>
<Students>
<Student>
<Ordinal>1</Ordinal>
<Name>Student1</Name>
<BirthDate>Date1</BirthDate>
<ID>ID1</ID>
</Student>
<Student>
<Ordinal>2</Ordinal>
<Name>Student2</Name>
<BirthDate>Date2</BirthDate>
<ID>ID2</ID>
</Student>
</Students>";
// Parse string is equivalent to load path. 
XDocument xDoc = XDocument.Parse(input);
XElement xEl = XElement.Parse(input);
var xDocString = xDoc.ToString();
var XElElement = xEl.Element("Student").ToString();
// => <Student>  <Ordinal>1</Ordinal> ...
var XElDecendant = xEl.Descendants("Student").ToString();
// => System.Xml.Linq.XContainer+<GetDescendants>d__39
// I'm a linQ container containing XNode, please enumerate me. 
	
var xDocElement = xDoc.Element("Student").ToString();
//=> null
var xDocDecendant = xDoc.Descendants("Student").ToString();            
// => System.Xml.Linq.XContainer+<GetDescendants>d__39
// I'm a linQ container containing XNode, please enumerate me. 
foreach(var el in xEl.Descendants("Student")){
    Console.WriteLine(el);
}		
