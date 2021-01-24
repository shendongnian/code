        var GoodAnswers = new List<string>();
        GoodAnswers.Add("It is certain.");
        GoodAnswers.Add("It is decidedly so.");
        GoodAnswers.Add("Without a doubt.");
        var NegativeAnswers = new List<string>();
        NegativeAnswers.Add("It is not certain.");
        NegativeAnswers.Add("It is not decidedly so.");
        NegativeAnswers.Add("With a doubt.");
        Magic8Ball_Logic.Magic8Ball ball = new Magic8Ball_Logic.Magic8Ball();
        if (SomeCondition)
        {
            ball = new Magic8Ball(GoodAnswers);
        }
        else
        {
            ball = new Magic8Ball(NegativeAnswers);
        }
            
