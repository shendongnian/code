    Document document =                                   // a Word document 
    Paragraphs paragraphs = document.Paragraphs;          // grab the collection
    var punk = Marshal.GetIUnknownForObject(paragraphs);  // get IUnknown
    Paragraphs p2 = document.Paragraphs;                  // get the collection again
    var punk2 = Marshal.GetIUnknownForObject(p2);         // get its IUnknown
    Debug.Assert(punk.Equals(punk2));                     // This is TRUE!
