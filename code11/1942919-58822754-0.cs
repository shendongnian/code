    private void button1_Click(object sender, EventArgs e)
    {
    	int beginrow = 5;
    	int totalCount = 15;
    	
    	int takeCount = 14;
    	int count = 0;
    	
    	var myList = new List<string>();
    	
    	for(var i  = beginrow; i < totalCount; i ++)
    	{		
    		count ++;
    		myList.Add(dataGridView1.Rows[beginrow + i].Cells[1].Value.ToString().Trim());
    		
    		if(count == takeCount)
    		{
    			break;
    		} 
    		else if(i + 1 == totalCount) 
    		{
    			i = -1;
    		}
    	}
    }
