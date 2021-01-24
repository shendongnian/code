    public class DialogueManager
    {
        private static IReadOnlyCollection<PropertyInfo> AllProperties = typeof(DialogueManager).GetProperties();
        private T GetPropertyValueSafe<T>(string propertyName)
        {
            PropertyInfo thePropertyInfo = DialogueManager.AllProperties.SingleOrDefault(x => x.Name == propertyName);
            if (thePropertyInfo is null)
            {
                throw new InvalidOperationException($"Type {this.GetType()} has no property {propertyName}.");
            }
            return (T) thePropertyInfo.GetValue(this);
        }
        private string ArrayToString<T>(T[] array)
        {
            return String.Join(", ", array);
        }
        public string GetText(int currentText)
        {
            return this.GetPropertyValueSafe<string>("text" + currentText);
        }
        public string GetTextChoices(int textNum)
        {
            return this.GetPropertyValueSafe<string>("choices" + textNum);
        }
        public int[] GetChoicesConsequences(int textNum)
        {
            return this.GetPropertyValueSafe<int[]>("consequences" + textNum);
        }
        public string text1 { get; set; } = "Text 1";
        public string choices1 { get; set; } = "Choice 1";
        public int[] consequences1 { get; set; } = new int[] { 1, 2 };
        public string text2 { get; set; } = "Text 2";
        public string choices2 { get; set; } = "Choice 2";
        public int[] consequences2 { get; set; } = new int[] { 1, 2, 3 };
        public static void Main(string[] args)
        {
            DialogueManager d = new DialogueManager();
            Console.WriteLine(d.ArrayToString(d.GetChoicesConsequences(1)));
            Console.WriteLine(d.GetText(1));
            Console.WriteLine(d.GetTextChoices(1));
            Console.WriteLine(d.ArrayToString(d.GetChoicesConsequences(2)));
            Console.WriteLine(d.GetText(2));
            Console.WriteLine(d.GetTextChoices(2));
            Console.ReadLine();
        }
    }
