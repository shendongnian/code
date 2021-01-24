	int count = 0; //how many strings in buf
	string[] buff = new string[2]{ "", "" }; //here we will store our results
	for (int i = 0; i < users.Length; i++)
	{
		string[] usernameandpassword = users[i].Split("~");
		for (int wordIndex = 0; wordIndex < usernameandpassword.Length; wordIndex++)
		{
			buff[count] = usernameandpassword[wordIndex];
			count++;
			if (count > 1)
			{
				if (username == buff[0] && password == buff[1])
				{
					userfound = true;
					break;
				}
                count = 0;
			}
		}
	}
