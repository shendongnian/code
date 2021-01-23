     class ItemWithIndex
     {
     	public string Text { get; set; }
     	public int StartIndex { get; set; }
     	public int EndIndex { get; set; }
     	
     	public override string ToString()
     	{
     		return string.Format(
                     "{0}: Starts at {1}, Ends at {2}", 
                     Text, StartIndex, EndIndex);
       	 }
     }
    
