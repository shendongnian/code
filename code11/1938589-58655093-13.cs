    var AllcombinedList = new List<Tuple<PlayerHandler, PlayerMovement>>();
    int count = Math.Min(SaveValuesDeserialize.Count, NoteValuesDeserialzeList.Count);
    // Or raise an exception if SaveValuesDeserialize.Count != NoteValuesDeserialzeList.Count
    // Or ask the user what to do with the rest if it can happen
    // Else use count = SaveValuesDeserialize.Count for example if always same
    for ( int index = 0; index < count; index++ )
    {
      var item = new Tuple<PlayerMovement, PlayerHandler>(NoteValuesDeserialize[index],
                                                          SaveValuesDeserialzeList[index]);
      AllcombinedList.Add(item);
    }
