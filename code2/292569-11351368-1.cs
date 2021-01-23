    int LongestItemLength = 0;
    for (int i = 0; i < listBox1.Items.Count;i++ ){
    	Graphics g = listBox1.CreateGraphics();
    	int tempLength = Convert.ToInt32((
    			g.MeasureString(
    					listBox1.Items[i].ToString(), 
    					this.listBox1.Font
    				)
    			).Width);
    	if (tempLength > LongestItemLength){
    		LongestItemLength = tempLength;
    	}
    }
    listBox1.Width = LongestItemLength;
    listBox1.Show(); 
        
