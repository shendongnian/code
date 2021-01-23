	private IList<Class2> myArray;
	[XmlIgnore]
	public IList<Class2> MyArray
	{
		get { return myArray; }
		set { myArray = value; }
	}
	[XmlElement("MyArray")]
	public object MyArraySerializable
	{
		get { return MyArray; }
		set { MyArray = value as IList<Class2>; }
	}
