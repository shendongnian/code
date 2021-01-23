    public static List<int[]> Combine(int[] elements, int maxValue)
    {
        LinkedList<int[]> result = new LinkedList<int[]>();
        List<int> listElements = new List<int>(elements);
        listElements.Sort();
        Combine(listElements.ToArray(), maxValue, new int[0], result);
        return result.ToList();
    }
    private static void Combine(int[] elements, int maxValue, int[] stack, LinkedList<int[]> result)
    {
        if(elements.Length > 0 && maxValue >= elements[0])
        {				
            var newElements = elements.Skip(1).ToArray();
            for (int i = maxValue / elements[0]; i > 0; i--)
            {
                result.AddLast(stack.Concat(Enumerable.Repeat(elements[0], i)).ToArray());	
                Combine(newElements, maxValue - i*elements[0], result.Last(), result);
            }
            Combine(newElements, maxValue, stack, result);
        }
    }
