    List<object> AllcombinedList = new List<object>();
    int count = Math.Min(SaveValuesDeserialize.Count, NoteValuesDeserialzeList.Count);
    // Or raise an exception if SaveValuesDeserialize.Count != NoteValuesDeserialzeList.Count
    // Or ask the user what to do
    for ( int index = 0; index < count; index++ )
    {
      AllcombinedList.Add(SaveValuesDeserialize[index]);
      AllcombinedList.Add(NoteValuesDeserialzeList[index]);
    }
