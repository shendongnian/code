    public double getScore(String grade)
    {
    	grade = grade.ToUpper();
    	if(grade.Length > 2 || grade.Length <= 0)
    	{
    		throw new ArgumentException();
    	}
    	var baseGrade = (double)grade[0];
    	if(baseGrade < 65 || baseGrade > 90)
    		throw new ArgumentException();
    	
    	if(grade.Length == 2)
    	{
    		var gradeShift = grade[1];
    		switch(gradeShift)
    		{
    			case '+':
    				baseGrade -= 0.3;
    				break;
    			case '-':
    				baseGrade += 0.3;
    				break;
    			default:
    				throw new ArgumentException();
    		}
    	}
    	
    	return baseGrade * -1 + 90.5;
    }
