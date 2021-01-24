    class Program
    {
        private static Random Random = new Random();
        static void Main(string[] args)
        {
            Button[] buttons = new Button[81];
            //Code to initialize Buttons
            int[] indexes = GetNRandomIndexesBetweenInts(0, buttons.Length, 10);
            foreach (int index in indexes)
            {
                buttons[index].Text = "B";
            }
        }
        private static int[] GetNRandomIndexesBetweenInts(int min, int maxPlusOne, int nRandom)
        {
            List<int> indexes = Enumerable.Range(min, maxPlusOne).ToList();
            List<int> pickedIndexes = new List<int>();
            for (int i = 0; i < nRandom; i++)
            {
                int index = indexes[Random.Next(0, indexes.Count)];
                pickedIndexes.Add(index);
                indexes.Remove(index);
            }
            return pickedIndexes.ToArray();
        }
    }
    public class Button
    {
        public string Text { get; set; }
    }
