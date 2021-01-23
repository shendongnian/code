    public class CombinationGenerator{
        private readonly Dictionary<int, int> currentIndexesWithLevels = new Dictionary<int, int>();
        private readonly LinkedList<List<int>> _combinationsList = new LinkedList<List<int>>();
        private readonly int _combinationLength;
        public CombinationGenerator(int combinationLength)
        {
            _combinationLength = combinationLength;
        }
        private void InitializeLevelIndexes(List<int> list)
        {
            for (int i = 0; i < _combinationLength; i++)
            {
                currentIndexesWithLevels.Add(i+1, i);
            }
        }
        private void UpdateCurrentIndexesForLevels(int level)
        {
            int index;
            if (level == 1)
            {
                index = currentIndexesWithLevels[level];
                for (int i = level; i < _combinationLength + 1; i++)
                {
                    index = index + 1;
                    currentIndexesWithLevels[i] = index;
                }
            }
            else
            {
                int previousLevelIndex;
                for (int i = level; i < _combinationLength + 1; i++)
                {
                    if (i > level)
                    {
                        previousLevelIndex = currentIndexesWithLevels[i - 1];
                        currentIndexesWithLevels[i] = previousLevelIndex + 1;
                    }
                    else
                    {
                        index = currentIndexesWithLevels[level];
                        currentIndexesWithLevels[i] = index + 1;
                    }
                }
            }
        }
        public void FindCombinations(List<int> list, int level, Stack<int> stack)
        {
            int currentIndex;
            InitializeLevelIndexes(list);
            while (true)
            {
                currentIndex = currentIndexesWithLevels[level];
                bool levelUp = false;          
                for (int i = currentIndex; i < list.Count; i++)
                {
                    if (level < _combinationLength)
                    {
                        currentIndex = currentIndexesWithLevels[level];
                        MoveToUpperLevel(ref level, stack, list, currentIndex);
                        levelUp = true;
                        break;
                    }
                    levelUp = false;
                    stack.Push(list[i]);
                    if (stack.Count == _combinationLength)
                    {
                        AddCombination(stack);
                        stack.Pop();
                    }                                                                                 
                }
                if (!levelUp)
                {
                    MoveToLowerLevel(ref level, stack, list, ref currentIndex);
                    while (currentIndex >= list.Count - 1)
                    {
                        if (level == 1)
                        {
                            AdjustStackCountToCurrentLevel(stack, level);
                            currentIndex = currentIndexesWithLevels[level];
                            if (currentIndex >= list.Count - 1)
                            {
                                return;
                            }
                            UpdateCurrentIndexesForLevels(level);
                        }
                        else
                        {
                            MoveToLowerLevel(ref level, stack, list, ref currentIndex);
                        }
                  }
              }                               
           }
        }
        private void AddCombination(Stack<int> stack)
        {
            List<int> listNew = new List<int>();
            listNew.AddRange(stack);
            _combinationsList.AddLast(listNew);
        }
        private void MoveToUpperLevel(ref int level, Stack<int> stack, List<int> list, int index)
        {
            stack.Push(list[index]);
            level++;
        }
        private void MoveToLowerLevel(ref int level, Stack<int> stack, List<int> list, ref int currentIndex)
        {
            if (level != 1)
            {
                level--;
            }
            AdjustStackCountToCurrentLevel(stack, level);
            UpdateCurrentIndexesForLevels(level);
            currentIndex = currentIndexesWithLevels[level];
        }
        private void AdjustStackCountToCurrentLevel(Stack<int> stack, int currentLevel)
        {
            while (stack.Count >= currentLevel)
            {
                if (stack.Count != 0)
                    stack.Pop();
            }
        }
        public void PrintPermutations()
        {
            int count = _combinationsList.Where(perm => perm.Count() == _combinationLength).Count();
            Console.WriteLine("The number of combinations is " + count);
        }
       
    }
