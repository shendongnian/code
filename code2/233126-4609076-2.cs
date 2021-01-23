    // set the dimensions of the labels to generate
    var rowCount = 10;  // set appropriate row count here
    var colCount = 8;
    // use LINQ to generate the cell labels.
    // make it static if dimensions are large
    // or would otherwise generate this once
    var cellLabels = (from r in Enumerable.Range(1, rowCount)
                      from c in Enumerable.Range('A', colCount)
                                          .Select(Convert.ToChar)
                      // create the labels
                      select String.Format("{0}{1:d02}", c, r))
                      // convert to a dictionary
                     .Select((Key, i) => new { Key, Value = i + 1 })
                     .ToDictionary(p => p.Key, p => p.Value.ToString());
    string letter0 = ...;
                      // assuming letter0 will be in the
                      // range of the generated cell labels
    var stringToSet = cellLabels[letter0];
