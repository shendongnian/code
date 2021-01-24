c#
bool IsCyclicPermutation(int[] a, int[] b) {
	if (a == null || b == null || a.Length != b.Length) return false;
	
	for (int i = 0; i < a.Length; i++)
	{
		if (a[i] == b[0]) // Potential starting point of cycle found
		{
			bool isCyclic = true;
			for (int j = 1; j < b.Length && isCyclic; j++)
			{
				if (a[(j + i) % a.Length] != b[j]) isCyclic = false;
			}
			if (isCyclic) return true; // Cycle found
		}
	}
	
	return false; // No cycles found
}
The following tests have been performed:
c#
var arr1 = new int[] {1, 2, 3};
var arr2 = new int[] {2, 3, 1};
var arr3 = new int[] {3, 1, 2};
var arr4 = new int[] {2, 1, 3};
IsCyclicPermutation(arr1, arr1); // True
IsCyclicPermutation(arr1, arr2); // True
IsCyclicPermutation(arr1, arr3); // True
IsCyclicPermutation(arr2, arr1); // True
IsCyclicPermutation(arr2, arr2); // True
IsCyclicPermutation(arr2, arr3); // True
IsCyclicPermutation(arr3, arr1); // True
IsCyclicPermutation(arr3, arr2); // True
IsCyclicPermutation(arr3, arr3); // True
IsCyclicPermutation(arr4, arr1); // False
IsCyclicPermutation(arr4, arr2); // False
IsCyclicPermutation(arr4, arr3); // False
As for performance, it's hard to tell without something to compare it against.
