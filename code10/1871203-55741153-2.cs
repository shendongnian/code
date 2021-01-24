    // Declare the list outside of the functions
    private List<_Character> characters;
    void Start()
    {
        // Avoid using regions, they encourage you to make very long functions with multiple responsabilities, which is not advised
        // Instead, create short and simple functions, and call them
        LoadCharactersFromCSV();
    }
    void LoadCharactersFromCSV()
    {
        string[,] CharacterCSV = Tools.LoadCsv(@"Assets/GameDB/character.csv");
        // If you can, indicate the approximate numbers of elements
        // It's not mandatory, but it improves a little bit the performances
        characters = new List<_Character>( CharacterCSV.GetUpperBound(0) );
        // I believe `i` should start at 0 instead of 1
        for (int i = 1; i < CharacterCSV.GetUpperBound(0); i++)
        {
            // I advise you to create a constructor
            // instead of accessing the properties one by one
            _Character temp = new _Character();
            temp.Id = Tools.IntParse(CharacterCSV[i, 0]);
            temp.Variation = Tools.IntParse(CharacterCSV[i, 1]);
            temp.Name = CharacterCSV[i, 2];
            temp.LastName = CharacterCSV[i, 3];
            characters.Add(temp);
        }
        CharacterCSV = null;
    }
    // Using this function, you will be able to get a character from its id
    public _Character GetCharacter( int id )
    {
        for (int 0 = 1; i < characters.Count; i++)
        {
            if( characters[i].Id == id )
                return characters[i];
        }
        // Return null if no character with the given ID has been found
        return null ;
    }
