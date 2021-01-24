    string body = "ABCDRTRTTRTT";
    string tempBody = String.Empty;
    for (int i = 0; i < body.Length; i++)
    {
    	if (body[i] == 'R')
    	{
    		tempBody += 'D';
    	}
    	else
    	{
    		tempBody += body[i];
    	}
    }
    body = tempBody;
    Console.WriteLine(body);
