    string search = "SMITH 9-2 #3-10H13";
    string myMatch = myRegex.Match(search).Value;
    string[] numberArray = myMatch.Split('-'); //grab the two numbers as separate strings
    if (numberArray.Length == 2)
    {
        int num1 = Int32.Parse(numberArray[0]);
        int num2 = Int32.Parse(numberArray[1]);
        string str1 = (num1 < 10 ? "0" + num1.ToString() : num1.ToString());
        string str2 = (num2 < 10 ? "0" + num2.ToString() : num2.ToString());
        string result = " " + str1 + "-" + str2 + " ";
        search = search.Replace(myMatch, result);
    }
    else
    {
        throw new Exception("Bad result!"); //sanity check, so you know if it goes wrong
    }
