    List<string> partList = new List<string>();
    
    // Build the original list first.
    foreach (var item in aListBox.Items)
    {
        // Creates a string of the items in the ListBox.
        var newItems = item.ToString();
    
        // Replaces any multiple spaces (tabs) with a single space.
        newItems = Regex.Replace(newItems, @"\s+", " ");
    
        // Splits each line by spaces.
        var eachItem = newItems.Split(' ');
    
        partList.Add(eachItem[1]);
    }
    
    // Now run through that list and count how many times the same number occurs.
    // You will need two loops for this since your list is a single dimension collection.
    foreach(var number in partList)
    {
      var innerList = partList;
    
      // set this to zero because we are going to find at least 1 duplicate.
      var count = 0;
      
      foreach(var additionalNumber in innerList)
      {
        if(additionalNumber == number)
         {
           // If we find anymore increase the count each time.
           count += 1;
         }
      }  
        
       // Now we have the full count of duplicates of the outer number in the list.
       sw.WriteLine(partList + ": " + count);
    
      
    }
