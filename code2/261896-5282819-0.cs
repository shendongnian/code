    internal abstract class EnumerableSorter<TElement>
    {
        // Methods
        [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        protected EnumerableSorter();
        internal abstract int CompareKeys(int index1, int index2);
        internal abstract void ComputeKeys(TElement[] elements, int count);
        private void QuickSort(int[] map, int left, int right);
        internal int[] Sort(TElement[] elements, int count);
    }
