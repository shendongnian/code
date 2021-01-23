    void WriteStars(int Width,int Height)
    {
    	int _sp=1; //Star Pos
    	bool _left = false;
    	for(int i =0;i<Height;i++)
    	{
    		Console.Write("|");
    		int j;
    		for(j=1;j<Width-1;j++)
    		{
    			if(j==_sp)
    			{
                    Console.Write("*");
    				if(_left)
    				{
    					_sp--;
    				}
    				else
    				{
    					_sp++;
    				}
                       j++;
                       break;
    			}
    			else
    			{
    			   Console.Write("_");
    			}
    		}
    		for(;j<Width-1;j++)
    		{
    			Console.Write("_");
    		}
    		
    		Console.WriteLine("|");
    		if(_sp==0)
    		{
    			_left = false;
    		}
    		else if(_sp==Width)
    		{
    			_left = true;
    		}
    
    	}
    }
