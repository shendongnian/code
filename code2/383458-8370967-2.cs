    int count = reader.FieldCount;
    while(reader.Read()) {
        for(int i = 0 ; i < count ; i++) {
            Console.WriteLine(reader.GetValue(i));
        }
    }
