	List<MyObject> ObjectList = new List<MyObject>();
	struct MyObject
	{
	    int Property1;
	    string Property2;
	    bool Property3;
	}
	
	while (buffer = StreamReader.ReadLine())
	{
	    string[] LineData = buffer.Split(',');
	    if (LineData[42] == "true") continue;
	    MyObject CurrentObject = new MyObject();
	    CurrentObject.Property1 = Convert.ToInt32(LineData[1]);
	    CurrentObject.Property2 = LineData[2];
	    CurrentObject.Property3 = Convert.ToBoolean(LineData[42]);
	    ObjectList.Add(CurrentObject);
	}
