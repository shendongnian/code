    const string Id = "Miss Piggy";
    var x = paragraphs[1];                   // get first paragraph
    Debug.Assert(x.ID == null);              // make sure it is empty first 
    x.ID = Id;                               // assign an ID 
    punk = Marshal.GetIUnknownForObject(x);  // get IUnknown
    // get it again
    var y = paragraphs[1];                   // get first paragraph AGAIN
    Debug.Assert(x.ID == Id);                // true
    punk2 = Marshal.GetIUnknownForObject(y); // get IUnknown
    Debug.Assert(punk.Equals(punk2));        // FALSE!!! Therefore different RCW
