    boolean isCorrect;
	public boolean checkBraces(String braces)
	{
		Stack<Character>stack = new Stack<Character>();
		int openBCount = 0;
		int closeBCount = 0;																
		
		for(int c = 0; c<=braces.length()-1; c++)
		{
			//check for open braces push to stack
																		
			if(braces.charAt(c)=='{' || braces.charAt(c)=='[' ||braces.charAt(c)=='(')
			{
				
				
				stack.push(braces.charAt(c));
				openBCount++;
													
			}																		////check for close braces. pop the open braces
																					 //compare it to the closed braces using the the 
																					 //method ValidatePerBraces																		 
																					 //therefor checking for CORRECTNEES of how the braces																		 //are closed
			else if(braces.charAt(c)=='}' || braces.charAt(c)==']' || braces.charAt(c)==')')
			{
				
				closeBCount++;
				if(!ValidatePerBraces(stack.pop(), braces.charAt(c))) 
				{
					isCorrect = false; //return false in case where they dont match
					return isCorrect;
				}
							
			}
									//for braces to be complete, open and close braces
									//should be even, if they are not even then it is 
									//for sure wrong at least for the specification.
			if(c>=braces.length()-1)
			{
												
				if(openBCount != closeBCount)
				{
					isCorrect = false; 
					return isCorrect;
				}
			}
					
		}
		
		
		isCorrect = true; // true if they all match
		
		return isCorrect;
	}
	
	// returns true if validated
	public boolean ValidatePerBraces(char a, char b)
	{
		
		return a == '(' && b== ')' || a == '[' &&  b == ']' || a == '{' && b== '}' ;
	
	}
