    [DelimitedRecord(",")]
    public class Test
    {
        public int SomeInt { get; set; }
        public string SomeString { get; set; }
        public int SomeInt1 { get; set; }
        public override string ToString() =>
            $"{SomeInt} - {SomeString} - {SomeInt1}";
    }
    var result = new FileHelperEngine<Test>()
        .ReadString(@"123,That's the string")
        .Single();
    Console.WriteLine(result);
