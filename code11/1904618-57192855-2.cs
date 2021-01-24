    class Program
    {
        static void Main(string[] args)
        {
            var input = @"        {..}P1, {.sdfsdfsdf.}P2, {.sdfsdfsdf.}P3, {..}P3
        {..}P4, {..}P1, {..}P8886, {..}P5";
            var items = Extractinator(input).Distinct().OrderBy(x => x).ToList();
            Console.WriteLine(string.Join(", ", items));
            Console.ReadLine();
        }
        static IEnumerable<string> Extractinator(string source)
        {
            var state = States.Extraneous;
            string item = "";
            foreach (var c in source)
            {
                switch (state)
                {
                    case States.Extraneous:
                        switch (c)
                        {
                            case '{':
                                state = States.InsideBrackets;
                                break;
                        }
                        continue;
                    case States.InsideBrackets:
                        switch (c)
                        {
                            case '}':
                                state = States.BuildingItem;
                                break;
                        }
                        continue;
                    case States.BuildingItem:
                        switch (c)
                        {
                            case char _ when char.IsDigit(c) || char.IsLetter(c):
                                item += c;
                                break;
                            default:
                                yield return item;
                                item = "";
                                state = States.Extraneous;
                                break;
                        }
                        continue;
                }
            }
            if (item != "")
                yield return item;
        }
        enum States
        {
            Extraneous,
            InsideBrackets,
            BuildingItem,
        }
    }
