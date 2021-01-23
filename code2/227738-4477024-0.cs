    // Copy array to temporary array
    for (int index=0; index < lines.Length; index++)
    {
        // System.ArgumentOutOfRangeException was unhandled
        // Index was out of range. Must be non-negative and less than the size of the collection.
        if (lines[index].Length >= 0)
        {
            temp[index] = lines[index];
        }
     }
     // Check for duplicates. If duplicate ignore if non-duplicate add to list.
     foreach (string line in temp)
     {
       if (!newlist.Contains(line))
       {
           newlist.Add(line);
       }
     }
     lstBox.Items.Clear();
     foreach (string strNewLine in newlist)
     {
        lstBox.Items.Add(strNewLine);
     }
