    // first get the summary; it is a descendant of doc & there's only one.
    var summary = doc.Descendants("summary").Single();
    
    // get the element with 'SomeAttribute' from the summary;
    // if there's only even going to be one then you can call Single here
    var item = summary.Elements().Single(e => e.Name == "item" 
        && e.Attribute("key").Value == "SomeAttribute");
    
    var q = item.Elements().Select(e => new 
        { LengendKey = e.Attribute("key").Value, ElapsedTime = e.Value });
