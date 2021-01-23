    List<string> matches = new List<string>();
    List<string> textInput = new List<string>(new[] {"a", "b", "c"});
    textInput.Sort();
    List<string> textCompare = new List<string>(new[] { "b", "c", "d" }); ;
    textCompare.Sort();
    int increment = 0;
    for (int i = textCompare.Count - 1; i >= 0; i--)
    {
        if (textCompare[i] == null)
        {
            textCompare.RemoveAt(i);
        }
    }
    matches = textInput.Intersect(textCompare).ToList();
