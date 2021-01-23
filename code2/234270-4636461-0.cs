    string ip = "192.168.0.1";
    string[] tokens = ip.Split('.');
    int value1 = Int32.Parse(tokens[0]);   // 192
    int value2 = Int32.Parse(tokens[1]);   // 168
    int value3 = Int32.Parse(tokens[2]);   // 0
    int value4 = Int32.Parse(tokens[3]);   // 1
