    private void button1_Click(object sender, EventArgs e)
    {
    	int beginrow = 5;
    	
    	int takeCount = 14;
    	int count = 0;
    	
    	var myList = new List<string>();
    	
    	for(var i  = beginrow; i < dataGridView1.RowCount && count < takeCount; i ++)
    	{		
    		count ++;
    		myList.Add(dataGridView1.Rows[beginrow + i].Cells[1].Value.ToString().Trim());
    		
    		if(i + 1 == dataGridView1.RowCount) 
    		{
    			i = -1;
    		}
    	}
    }
