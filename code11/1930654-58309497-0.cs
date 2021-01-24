    var chosenOnes = snowmen;
    if (Column1 != null)
        chosenOnes = chosenOnes.Where(a => a.GetType().GetProperty(Column1 + "Prop").GetValue(a, null).ToString() == values[i]);
            
    if (Column2 != null)
        chosenOnes = chosenOnes.Where(a => a.GetType().GetProperty(Column2 + "Prop").GetValue(a, null).ToString() == values[i+1]);
    if (Column3 != null)
        chosenOnes = chosenOnes.Where(a => a.GetType().GetProperty(Column3 + "Prop").GetValue(a, null).ToString() == values[i+2]);
