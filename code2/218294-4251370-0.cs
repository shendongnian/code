    public string SetStart(int startAt)
    {
        const string sentence = "this is a test so it is";
        var words = sentence.Split(' ');
        var x = (startAt > words.Count()) ? words.Count()%startAt : startAt;
        
        return string.Join(" ", words.Skip(x).Concat(words.Take(x)));            
    }
