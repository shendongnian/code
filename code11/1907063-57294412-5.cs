    string input = "test1234|5678|9";
    var result1 = input.Split('|')
    	.Where(y => y.All(char.IsDigit)).ToArray();
                                       //^^^^^^^ Convert to string array
    int[] intResult = Array.ConvertAll(result1, int.Parse);
                          //^^^^^^^ Convert all array elements to int
