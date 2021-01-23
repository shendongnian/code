    void DoProblem()
    {
        //string[] arrSample = new string[] { "!=", "=" };
        string[] arrSample = new string[] { "!=", "<","+" };
        string[][] arrPairs = (from op in arrSample select new string[]{op, GetReverse(op)}).ToArray();
            
        List<Array> myList = new List<Array>();
        myList.AddRange(arrPairs);
        foreach (string x in Permute(0, myList))
        {
            Console.WriteLine(x);
        }
        
    }
    List<string> Permute(int a, List<Array> x)
    {
        List<string> retval = new List<string>();
        if (a == x.Count)
        {
            retval.Add("");
            return retval;
        }
        foreach (Object y in x[a])
        {
            foreach (string x2 in Permute(a + 1, x))
            {
                retval.Add(y.ToString() + "," + x2.ToString());
            }
        }
        return retval;
    }
    string GetReverse(string op)
    {
        switch (op) {
            case "=":
                return "!=";
            case "!=":
                return "=";
            case "<":
                return ">";
            case "+":
                return "-";    
            default:
                return "";
        }
    }
