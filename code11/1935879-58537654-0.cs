    using System.Data;
    ...
    const string stringSequence = "1,3,2,5,4,7,6";
    IEnumerable<int> intSequence = 
        stringSequence.Split(',').Select(item => item[0])
                      .Select(c => (int)Char.GetNumericValue(c));
    Dictionary<int, int> sequenceToIndex = 
        intSequence.Select((s, i) => new { s, i})
                   .ToDictionary(item => item.s, item => item.i);
    IEnumerable<DataRow> sortedRows = 
        dataTable.AsEnumerable()
                 .OrderBy(r => sequenceToIndex[r.Field<int>("Sequence")]);
