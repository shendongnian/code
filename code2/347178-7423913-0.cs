    [Flags]
    enum Choices
    {
        OptionOne = 0x0,
        OptionTwo = 0x1    
    }
    class MyClass
    {
        Choices mychoice = Choices.OptionOne | Choices.OptionTwo;
    }
