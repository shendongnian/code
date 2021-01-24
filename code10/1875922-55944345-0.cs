    private List<string> _answers;
   
    public Magic8Ball()
    {
        _answers = new List<string>();
        _answers.Add("It is certain.");
    }
   
    public Magic8Ball(List<string> answers)
    {
        _answers = answers;
    }
