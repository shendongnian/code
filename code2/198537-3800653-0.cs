    class Graph{
    	
    	//matrix[i,j] is true if there is a node from i to j
    	bool[,] matrix;
    	
    	private void BFS( int startNode )
    	{
    		int n = matrix.GetLength(0);
    		bool [] marks = new bool[n];
    		
    		Queue<int> nodes = new Queue();
    		nodes.Enqueue(startNode);
    		
    		while ( !nodes.Empty() )
    		{
    			int node = nodes.Dequeue();
    			
    			//set visited
    			marks[node] = true;
    			
    			List<int> adjs = GetAdyacents(node);
    			
    			foreach ( int adjacent in adjs ){
    				if ( !mark[adjacent] )
    					nodes.Enqueue(adjacent);
    			}
    			
    			Console.WriteLine("Visiting {0}", node);
    		}
    	}
    
    }
