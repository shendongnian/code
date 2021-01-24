    string doc1String = "<Root><Elements Letters=\"abc\"><Sub1/><Sub2/><sub3>def</sub3></Elements><Elements Letters=\"ghi\"><Sub1/><Sub2/><sub3>jkl</sub3></Elements></Root>";
    string doc2String = "<DiffRoot><DiffElements><DiffSub1/><DiffSub2>ghi</DiffSub2><DiffSub3/><DiffSub4/><DiffSub5/></DiffElements><DiffElements><DiffSub1/><DiffSub2>abc</DiffSub2><DiffSub3/><DiffSub4/><DiffSub5/></DiffElements></DiffRoot>";
    var doc1 = XDocument.Parse(doc1String); 
    var doc2 = XDocument.Parse(doc2String); // or XDocument.Load(fileName);
    
    // read doc1 letters and substitutions in a dictionary:
    var lettersLookup = new Dictionary<string, string>();
    foreach (var element in doc1.Descendants().Where(e => e.Name.LocalName == "Elements"))
    {
        string letters = element.Attributes().Single(a => a.Name.LocalName == "Letters").Value;
        string substitute = element.Descendants().Single(e => e.Name.LocalName == "sub3").Value;
        lettersLookup[letters] = substitute;
    }
    
    // Walk through the diffelements of doc2
    foreach (var diffElement in doc2.Descendants()
        .Where(e => e.Name.LocalName == "DiffElements"))
    {
        var diffSub2 = diffElement.Descendants().Where(d => d.Name.LocalName == "DiffSub2").Single();
    
        // Find a matching element in doc1
        if (lettersLookup.TryGetValue(diffSub2.Value, out string substitute))
        {
            diffSub2.Value = substitute;
        }
    }
    
    Console.WriteLine(doc2.ToString());
    // or doc2.Save(fileName);
