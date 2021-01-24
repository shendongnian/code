    void Main()
    {
    	Console.WriteLine(
    	TransformCustom("1,19,2,20,3,30",",,{ 0},{ 1},,")
    	);
    
    //Output: ,,2,20,,
    Console.WriteLine(
    TransformCustom("1,19,2,20,3,30",",,,,{ 0},{ 1}")
    );
    
    //Output: ,,,,3,30
    }
    
    private string TransformCustom(string input1, string input2)
    {
    	return string.Join(",",
    	input1.Split(',').Zip(input2.Split(','), (i1, i2) => new {i1, i2})
    		.Select(i => string.IsNullOrEmpty(i.i2)?"":i.i1));
    }
