    private static void Main(string[] args)
    {
        Mock<IDog> m = new Mock<IDog>();
        m.Object.Eat(null);
    }
