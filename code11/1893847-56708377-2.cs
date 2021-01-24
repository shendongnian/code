    int[] numbers = { -5, 3, 6, 9, -2, 1, 0, 4};
    
    int count = 8;
    
    List<string> word = new List<string>();
    
    private void Convert(List<string> wordArray, int count)
    {
    	
    	//Convert numbers
    	for (int index = 0; index < count; index++)
    	{
    		if (numbers[index] == 1)
    		{
    			wordArray.Add("one");
    		}
    		else if (numbers[index] == 2)
    		{
    			wordArray.Add("two");
    		}
    		else if (numbers[index] == 3)
    		{
    			wordArray.Add("three");
    		}
    		else if (numbers[index] == 4)
    		{
    			wordArray.Add("four");
    		}
    		else if (numbers[index] == 5)
    		{
    			wordArray.Add("five");
    		}
    		else if (numbers[index] < 1)
    		{
    			wordArray.Add("lower");
    		}
    		else
    		{
    			wordArray.Add("higher");
    		}
    	}
    }
    private void ConvertButton_Click(object sender, EventArgs e)
    {
    	wordListBox.Items.Clear();
    	Convert(word, count);
    	foreach (var item in word)
    	{
    		wordListBox.Items.Add(item);
    	}
    }
