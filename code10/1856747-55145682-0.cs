    CharacterProperties cp = document.BeginUpdateCharacters(document.Selection);
    cp.FontName = "Comic Sans MS";
    cp.FontSize = 18;
    cp.ForeColor = Color.Blue;
    cp.BackColor = Color.Snow;
    cp.Underline = UnderlineType.DoubleWave;
    cp.UnderlineColor = Color.Red;
    
    // Finalize modifications   
    // with this method call  
    document.EndUpdateCharacters(cp);
