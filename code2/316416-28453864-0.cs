    public static string[] SplitFullNameIntoNameAndSurname(string pFullName)
    {
    	string[] NameSurname = new string[2];
        string[] NameSurnameTemp = pFullName.Split(' ');
        for (int i = 0; i < NameSurnameTemp.Length; i++)
        {
        	if (i < NameSurnameTemp.Length - 1)
            {
            	if (!string.IsNullOrEmpty(NameSurname[0]))
                	NameSurname[0] += " " + NameSurnameTemp[i];
				else
                	NameSurname[0] += NameSurnameTemp[i];
			}
			else
            	NameSurname[1] = NameSurnameTemp[i];
		}
        return NameSurname;
	}
