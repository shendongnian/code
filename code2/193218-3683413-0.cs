    public int Height
            {
            	get { return _height; }
            	protected internal set
            	{
            		_height = value;        		        		
            	}
            }
            
            private void UpdateHeight()
            {
            	if (Left == null && Right == null) {
            		return;
            	}
            	if(Left != null && Right != null)
            	{
            		if (Left.Height > Right.Height)
            			Height = Left.Height + 1;
            		else
            			Height = Right.Height + 1;
            	}
            	else if(Left == null)
            		Height = Right.Height + 1;
            	else
            		Height = Left.Height + 1;
            	
            	var parent = Parent;
            	while (parent != null) {
            		parent.Height++;
    				parent = parent.Parent;        		
            	}       	
            	
            }
