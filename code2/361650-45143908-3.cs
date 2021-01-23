    public class СombinationGenerator
    {
        public void FindAllCombinations(List<int> list, int combinationLength)
        {
            _combinationsList = new LinkedList<List<int>>();
            foreach (var value in list)
            {
                GenerateCombinationsSecondApproach(value, combinationLength);
            }
        }
        private void GenerateCombinations(int value, int permutationLength)
        {
            var node = _combinationsList.First;
            var last = _combinationsList.Last;
            while(node!=null)
            {
                GreateCombination(node.Value, value, permutationLength);
                if(node == last)
                {
                    break;
                }
                node = node.Next;
            }
            List<int> permutation = new List<int>();
            permutation.Add(value);
            _combinationsList.AddLast(permutation);
        }
        private void GreateCombination(List<int> permutation, int value, int permutationLength)
        {
            List<int> copyOfInitialPermutation = new List<int>(permutation);
            if (copyOfInitialPermutation.Count < permutationLength)
            {
                copyOfInitialPermutation.Add(value);
                _combinationsList.AddLast(copyOfInitialPermutation);
            }
        }
        public void PrintCombinations(int combinationLength)
        {
            int count = _combinationsList.Where(perm => perm.Count() == combinationLength).Count();
            Console.WriteLine("The number of combinations is " + count);
        }
    }
