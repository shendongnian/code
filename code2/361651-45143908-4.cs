    public class СombinationGenerator
    {
        public void FindAllCombinations(List<int> list, int combinationLength)
        {
            _combinationsList = new LinkedList<List<int>>();
            foreach (var value in list)
            {
                GenerateCombinations(value, combinationLength);
            }
        }
        private void GenerateCombinations(int value, int combinationLength)
        {
            var node = _combinationsList.First;
            var last = _combinationsList.Last;
            while (node != null)
            {
                if (node.Value.Count < combinationLength)
                {
                    GreateCombination(node.Value, value, combinationLength);
                }
                if (node == last)
                {
                    break;
                }
                node = node.Next;
            }
            List<int> combination = new List<int>();
            combination.Add(value);
            _combinationsList.AddLast(combination);
        }
        private void GreateCombination(List<int> combination, int value, int combinationLength)
        {
            if (combination.Count < combinationLength)
            {
                List<int> copyOfInitialCombination = new List<int>(combination);
                copyOfInitialCombination.Add(value);
                _combinationsList.AddLast(copyOfInitialCombination);
            }
        }
        public void PrintCombinations(int combinationLength)
        {
            int count = _combinationsList.Where(perm => perm.Count() == combinationLength).Count();
            Console.WriteLine("The number of combinations is " + count);
        }
    }
