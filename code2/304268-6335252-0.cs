    private List<TextFiller> _textfillerDetails = new List<TextFiller>();
    public ABC(int capacity)
      {
         for(int index  = 0; index < capacity; index ++)
           _textfillerDetails.Add(new TextDetail());
      }
