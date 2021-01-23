    var xmlStr = @"<skills>
      <skill>
        <name>some name</name>
        <description>a skill</description>
        <type>high</type>
        <stat>perception</stat>
        <page>42</page>
        <availability>all</availability>
      </skill>
    </skills>
    ";
    var doc = XDocument.Parse(xmlStr);
    // find the skill "some name"
    var mySkill = doc
        .Descendants("skill") // out of all skills
        .Where(e => e.Element("name").Value == "some name") // that has the element name "some name"
        .SingleOrDefault(); // select it
    if (mySkill != null) // if found...
    {
        var skillType = mySkill.Element("type").Value; // read the type
        var skillPage = (int)mySkill.Element("page"); // read the page (as an int)
        mySkill.Element("description").Value = "an AWESOME skill"; // change the description
        // etc...
    }
