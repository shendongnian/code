	private int[] _elements;
	public int this[int index] //Indexed property
	{
		get { return this._elements[index]; }
		set
		{
			//Do any checks on the index and value
			this._elements[index] = value;
		}
	}
	
