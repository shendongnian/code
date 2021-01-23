    string[] names = Enum.GetNames(typeof(MyEnum));
    MyEnum[] values = (MyEnum[])Enum.GetValues(typeof(MyEnum));
    int[] intValues = values.Cast<int>().ToArray();
    for (int i = 0; i < names.Length; i++) {
    	Console.WriteLine("{0} = {1}", names[i], intValues[i]);
    }
