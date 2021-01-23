    Person myPerson = new Person();
    
    Misc tidyup = new Misc();
    string[] result = tidyup.SplitFullName(tb1.Text);
    
    foreach (string s in result)
    {
        Console.WriteLine(s);
    
        if (result.First() == s)
        {
            myPerson.FirstName = s;
        }
        else
        {
            myPerson.LastName += s + " ";
            Console.WriteLine(s);
            Console.WriteLine(myPerson.LastName);
        }
    }    
    
    public string[] SplitFullName(string myName)
    {
        string[] names = myName.Split(' ');
        //string firstName = names[0];
        //string lastName = names[1];
    
        return names;
    }
                    
