    public static class Test {
    static int check(this XElement element)
    {
        if(element.Value < 100 || element.Value > 275)
        {
            throw new Exception();
        }
        return element.Value;
    }
    }
