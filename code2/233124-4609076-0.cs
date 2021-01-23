    // set the dimensions of the labels to generate
    var rowCount = 10;  // set appropriate row count here
    var colCount = 8;
    // use LINQ to generate the cell labels.
    // make it static if dimensions are large
    // or would otherwise generate this once
    var cellLabels = (from c in Enumerable.Range('A', colCount)
                                          .Select(i => (char)i)
                      from r in Enumerable.Range(1, rowCount)
                      // create the labels
                      select String.Format("{0}{1:d02}", c, r))
                      // convert to an indexable list
                     .ToList();
    string letter0 = ...;
                      // assuming letter0 will be in the
                      // range of the generated cell labels
    var stringToSet = (cellLabels.IndexOf(letter0) + 1).ToString();
