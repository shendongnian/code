    public object MyMethod(string str1, string str2)
    {
        switch(something)
        {
                case 1:
                case 2:
                    return double.Parse(str1);
                break;
                case 3:
                case 4:
                    return int.Parse(str1);
                break;
                default
                    return null;
        }
    }
