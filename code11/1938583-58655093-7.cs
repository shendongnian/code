    var AllcombinedList = new List<PlayerItem>();
    int count = Math.Min(SaveValuesDeserialize.Count, NoteValuesDeserialzeList.Count);
    // Or raise an exception if SaveValuesDeserialize.Count != NoteValuesDeserialzeList.Count
    // Or ask the user what to do with the rest if it can happen
    // Else use count = SaveValuesDeserialize.Count for example if always same
    for ( int index = 0; index < count; index++ )
      AllcombinedList.Add(new PlayerItem
      {
        Handler = SaveValuesDeserialize[index],
        Movement = NoteValuesDeserialzeList[index]
      });
    public class PlayerItem
    {
      public PlayerHandler Handler { get; set; }
      public PlayerMovement Movement { get; set; }
    }
