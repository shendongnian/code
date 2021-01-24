    int count = Math.Max(SaveValuesDeserialize.Count, NoteValuesDeserialzeList.Count);
    for ( int index = 0; index < count; index++ )
    {
      var movement = index < NoteValuesDeserialzeList.Count 
                   ? NoteValuesDeserialzeList[index] 
                   : null;
      var handler = index < SaveValuesDeserialize.Count 
                  ? SaveValuesDeserialize[index] 
                  : null;
      AllcombinedList.Add(new PlayerItem
      {
        Movement = movement,
        Handler = handler
      });
    }
