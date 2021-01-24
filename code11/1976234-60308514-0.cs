string xml = @"<incident>
<id>1234</id>
<number>5678</number>
<name>This is a name</name>
<state>Awaiting Input</state>
<priority>Medium</priority>
<category>
    <id>99999</id>
    <name>Applications</name>
    <default_tags>applications</default_tags>
    <parent_id nil=""true"" />
    <default_assignee_id nil=""true"" />
</category>
</incident>";
			
		XmlDocument doc = new XmlDocument();
		doc.LoadXml(xml);
		var node = doc.DocumentElement;
			
		var id = node.SelectSingleNode("id")?.InnerText;  //works fine
	   var number = node.SelectSingleNode("number")?.InnerText;  //works fine
	   var name = node.SelectSingleNode("name")?.InnerText;  //works fine
	   var descHTML = node.SelectSingleNode("description")?.InnerText;  //ERRORS because there is no description.
	   var desc = node.SelectSingleNode("description_no_html")?.InnerText;  //works fine
	   var state = node.SelectSingleNode("state")?.InnerText;  //works fine
	   var priority = node.SelectSingleNode("priority")?.InnerText;  //works fine
	   var catagoryID = node.SelectSingleNode("//category/id")?.InnerText; // null reference error
	   var catagoryName = node.SelectSingleNode("//category/name")?.InnerText; // null reference error
	   var catagoryTags = node.SelectSingleNode("//category/default_tags")?.InnerText; // null reference error
		Console.WriteLine($"name: {name}");
		Console.WriteLine($"descHTML: {descHTML}");
		Console.WriteLine($"desc: {desc}");
		Console.WriteLine($"state: {state}");
		Console.WriteLine($"priority: {priority}");
		Console.WriteLine($"catagoryID: {catagoryID}");
		Console.WriteLine($"catagoryName: {catagoryName}");
		Console.WriteLine($"catagoryTags: {catagoryTags}");
**Output it prints out**
name: This is a name
descHTML: 
desc: 
state: Awaiting Input
priority: Medium
catagoryID: 99999
catagoryName: Applications
catagoryTags: applications
[Code on #dotnetfiddle](https://dotnetfiddle.net/n1Yydn)
