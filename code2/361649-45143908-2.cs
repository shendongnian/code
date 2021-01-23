    public class СombinationGenerator
    {
        public void FindAllCombinationsSecond(List<int> list, int combinationLength)
        {
            _combinationsList = new LinkedList<List<int>>();
            foreach (var value in list)
            {
                GenerateCombinationsSecondApproach(value, combinationLength);
            }
        }
        public void PrintCombinationsSecondApproach(int combinationLength)
        {
            int count = _combinationsList.Where(perm => perm.Count() == combinationLength).Count();
            Console.WriteLine("The number of combinations is " + count);
        }
        private void GenerateCombinationsSecondApproach(int value, int permutationLength)
        {
            var node = _combinationsList.First;
            var last = _combinationsList.Last;
            while(node!=null)
            {
                GreateCombinationSecondApproach(node.Value, value, permutationLength);
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
        private void GreateCombinationSecondApproach(List<int> permutation, int value, int permutationLength)
        {
            List<int> copyOfInitialPermutation = new List<int>(permutation);
            if (copyOfInitialPermutation.Count < permutationLength)
            {
                copyOfInitialPermutation.Add(value);
                _combinationsList.AddLast(copyOfInitialPermutation);
            }
        }
    }
