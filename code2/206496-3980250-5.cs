    public enum NumberedWords
    {
        zero = 0,
        one = 1,
        two = 2,
        three = 3,
        four = 4,
        five = 5
    }
    
    public static string ToName(this int value)
    {
        return (NumberedWords)value;
    }
 
