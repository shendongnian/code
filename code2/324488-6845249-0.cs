    public abstract class Generator
    {
        public Generator(int? i, string name) { }
        public abstract string GetBaseUrl();
    }
    
    public class GeneratorA : Generator
    {
        public GeneratorA(int? i, string name) : base(i, name) { }
    }
    public class GeneratorB : Generator
    {
        public GeneratorB(int? i, string name) : base(i, name) { }
    }
    public class GeneratorFactory
    {
        // Make singleton
        public GeneratorB GenerateB(int? i, string name)
        {
            return (GeneratorB)this.Generate(i, name, "GeneratorB");
        }
    
        public GeneratorA GenerateA(int? i, string name)
        {
            return (GeneratorA)this.Generate(i, name, "GeneratorA");
        }
    
        public Generator Generate(int? i, string name, string genType)
        {
            return new GeneratorA(); // use reflection to generate child generator based on string "genType"
        }
    }
