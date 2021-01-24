    public static void saveUser(String userName, String password, String boardId)
    {
    	DalUser u = new DalUser(userName, password, boardId);
    	using (var fileStream = new FileStream("userData.bin", FileMode.Append))
    	{
    		var bFormatter = new BinaryFormatter();
    		bFormatter.Serialize(fileStream, u);
    	}
    }
    
    public static List<DalUser> readUsers()
    {
    	if (!File.Exists("userData.bin"))
    		return null;
    	var list = new List<DalUser>();
    	using (var fileStream = new FileStream("userData.bin", FileMode.Open))
    	{
    		var bFormatter = new BinaryFormatter();
    		while (fileStream.Position != fileStream.Length)
    		{
    			list.Add((DalUser)bFormatter.Deserialize(fileStream));
    		}
    	}
    	return list;
    }
