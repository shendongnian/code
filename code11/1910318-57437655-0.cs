    var resultList = new List<string>() { string.Empty };
    var parts = line.Split(' ').ToList();
    for (int i = 0; i < parts.Count; i++)
    {
        // If the word contains your keyword, add it as a new item in the list.
        // Next add new item that is an empty string.
        if (parts[i].Contains(keyword))
        {
            resultList.Add(parts[i]);
            resultList.Add(string.Empty);
        }
        // Otherwise, add the word to the last item, and then add a space at the end to separate words.
        else
        {
            resultList[resultList.Count - 1] = resultList[resultList.Count - 1] + parts[i] + " ";
        }
    }
