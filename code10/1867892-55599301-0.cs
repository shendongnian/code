    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var assembly = typeof(Foo).Assembly;
            var types = assembly.ExportedTypes
                // Abrstract && Sealed = Static classes
                .Where(x => x.IsClass && !(x.IsAbstract && x.IsSealed));
            var builder = new StringBuilder("Class\tDeclared By\tMember type\tName\n");
            foreach (var type in types)
            {
                builder.AppendLine(GetTypeInformation(type));
            }
            // result is copied into the clipboard, just CTRL+V into Excel
            System.Windows.Forms.Clipboard.SetText(builder.ToString());
        }
        private static string GetTypeInformation(Type type)
        {
            var classInformationBuilder = new StringBuilder();
            foreach (var member in type.GetProperties())
            {
                classInformationBuilder.AppendLine($"{type.Name}\t{member.DeclaringType.Name}\t{member.PropertyType.Name}\t{member.Name}");
            }
            return classInformationBuilder.ToString();
        }
    }
    public abstract class Foo
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Quantity { get; set; }
    }
    public class Bar : Foo
    {
        public double Width { get; set; }
        public double Length { get; set; }
        public double Depth { get; set; }
    }
