    private void AssignEnabledOptions()
        {
        	int iBtnCount = 0;
        	string sVar1, sVar2, sVar3, sVar4, sVar5, sVar6;
        	char letter = 'A';
        
        	sVar1 = "2";
        	sVar2 = "1";
        	sVar3 = "1";
        	sVar4 = "1";
        	sVar5 = "0";
        	sVar6 = "1";
        
        	List<string> list = new List<string>
        	{
        		sVar1,
        		sVar2,
        		sVar3,
        		sVar4,
        		sVar5,
        		sVar6
        	};
        
        	for (int i = 0; i < list.Count; i++)
        	{
        		if (Convert.ToInt32(list[i]) > 0)
        		{
        			list[i] = ((char)(letter + iBtnCount)).ToString();
        			iBtnCount = iBtnCount + 1;
        		}
        		else
        		{
        			list[i] = "None";
        		}
        	}
        }
