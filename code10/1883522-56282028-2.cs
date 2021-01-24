    string lineRead = "apple mango orange grape";
    int i = 0;
    lineRead.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries)
    .ToList()
    .ForEach(item => { CLASS[0, i++] = item; });
