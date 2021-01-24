        void Start() {
    	int[, ] matrix = new int[6, 6];
    
    	InitMatrixRandom(matrix, 1, 100); //add here
    
    	PrintMatrix(matrix);
    
    	int SearchingNumberVariable = int.Parse(Console.ReadLine()); //change the name because conflicting with method name
    
    	Position loc = new Position();
    
    	loc = SearchingNumber(matrix, SearchingNumberVariable);
    
    }
    
    //Matrix writing
    void PrintMatrix(int[, ] matrix) {
    	//InitMatrixRandom(matrix, 1, 100); //remove this
    
    	for (int r = 0; r < matrix.GetLength(0); r++) {
    		for (int c = 0; c < matrix.GetLength(1); c++) {
    			Console.Write(matrix[r, c] + "\t");
    		}
    		Console.WriteLine();
    	}
    }
    
    //Matrix positie
    Position SearchingNumber(int[, ] matrix, int zoekGetal) {
    	//InitMatrixRandom(matrix, 1, 100); //remove this
    
    	Position loc = new Position();
    
    	for (int r = 0; r < matrix.GetLength(0); r++) {
    		if (r != zoekGetal) {
    			loc.row++;
    		}
    		for (int k = 0; k < matrix.GetLength(1); k++) {
    			if (k != zoekGetal) {
    				loc.collumn++;
    			}
    			else if (matrix[r, k] == zoekGetal) {
    				break;
    			}
    		}
    	}
    	return loc;
    }
