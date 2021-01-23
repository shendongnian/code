        int count = 0;
        string temp = "";
        string temp2 = "";
        for (Match m = Regex.Match(str, qmatch2); m.Success; m = m.NextMatch())
        {
            temp = m.Value;
            temp2 = Regex.Replace(temp, qmatch2, " . ");
            str = Regex.Replace(str, temp, temp2);
        }
        if (temp.Contains(".") == false)
        {
            using (var file = new StreamWriter("text6.txt"))
            {
                file.Write("text6.txt");
                file.WriteLine(" " + temp);                    
            }
            count++;
        } 
