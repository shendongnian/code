        var random = new Random();
		
		var list = new List<string> { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10"  };
		
		var newList1 = new List<string>();
		var newList2 = new List<string>();
		while(list.Count > 0)
		{
			//choose the index randomly
			int index = random.Next(list.Count);
			
			//get the item at the randomly chosen index
			string curItem = list[index];
			
			//choose the list randomly(1==newList1, 2==newList2)
			int listChoice = random.Next(2);
			
			//Add the item to the correct list
			if(listChoice == 1)
			{
				newList1.Add(curItem);
			}
			else
			{
				newList2.Add(curItem);
			}
			//finally, remove the element from the string
			list.RemoveAt(index);
		}
