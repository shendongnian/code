    private static void Main(string[] args)
    {
        Mock<IDog> m = new Mock<IDog>();
        IDog.V$Eat(m.Object, null);
    }
