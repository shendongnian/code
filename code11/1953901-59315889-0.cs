	class PermutationList : IEnumerable
	{
		List<int> _innerList;
		int _start;
		public PermutationList(List<int> list, int start) {
			_innerList = list;
			_start = start;
		}
		
		public IEnumerator GetEnumerator()
		{
			return new CustomEnumerator(_start, _innerList);
		}
	
		class CustomEnumerator : IEnumerator
		{
			public CustomEnumerator(int start, List<int> list)
			{
				_start = _current = start;
				_current--; // indexes are 0-based, so we adjust for that
				_list = list.ToArray();
				_items = list.Count;
				_iteration = 0;
			}
	
			int _start;
			int _items;
			int[] _list;
	
			int _current;
			int _iteration;
			public object Current => _list[_current];
	
			public bool MoveNext()
			{
				_iteration++;
				_current++;
				if (_current == _list.Count()) _current = 0; // this is where the wrap-around happens
	
				return _iteration <= _items; // we need to break as soon as we read all items in the list though. removing this condition will make the sequence run forever
			}
	
			public void Reset() => _current = _start;
		}
	}
	
	void Main()
	{
		List<int> intList1  = new List<int>() { 1, 4, 2, 8, 5, 7};	
		var p = new PermutationList(intList1, 3); // will go {8,5,7,1,4,2}
	}
