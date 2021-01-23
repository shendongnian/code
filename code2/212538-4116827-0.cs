    public static void Main(string[] args)
    {
        var testCases = new List<string>
        {
            "C11H22O12",
            "Al2O3",
            "O3",
            "C",
            "H2O"
        };
        foreach (string testCase in testCases)
        {
            Console.WriteLine("Testing {0}", testCase);
            var formula = FormulaFromString(testCase);
            foreach (var element in formula)
            {
                Console.WriteLine("{0} : {1}", element.Element, element.Count);
            }
            Console.WriteLine();
        }
        /* Produced the following output
            
        Testing C11H22O12
        C : 11
        H : 22
        O : 12
        Testing Al2O3
        Al : 2
        O : 3
        Testing O3
        O : 3
        Testing C
        C : 1
        Testing H2O
        H : 2
        O : 1
            */
    }
    private static Collection<ChemicalFormulaComponent> FormulaFromString(string chemicalFormula)
    {
        Collection<ChemicalFormulaComponent> formula = new Collection<ChemicalFormulaComponent>();
        string elementRegex = "([A-Z][a-z]*)([0-9]*)";
        string validateRegex = "^(" + elementRegex + ")+$";
        if (!Regex.IsMatch(chemicalFormula, validateRegex))
            throw new FormatException("Input string was in an incorrect format.");
        foreach (Match match in Regex.Matches(chemicalFormula, elementRegex))
        {
            string name = match.Groups[1].Value;
            int count =
                match.Groups[2].Value != "" ?
                int.Parse(match.Groups[2].Value) :
                1;
            formula.Add(new ChemicalFormulaComponent(ChemicalElement.ElementFromSymbol(name), count));
        }
        return formula;
    }
