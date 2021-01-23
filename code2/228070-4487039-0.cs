    string[] names = { "John", "Mary", "Stephanie", "David" };
    int iLast = names.Length - 1;
    for (int i = 0; i <= iLast; i++) {
    	Debug.Write(names[i]);
    	Debug.Write(i < iLast ? ", " : Environment.NewLine);
    }
