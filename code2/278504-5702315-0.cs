    class Player
    {
       public string Name;
    
       [XmlIgnore]
       public int[] Spells;
    
       [XmlElement("Spells")
       public string SpellsString
       {
         get
         {
            // array to space delimited string
         }
         set
         {
           // string to array conversion
         }
       }
    }
