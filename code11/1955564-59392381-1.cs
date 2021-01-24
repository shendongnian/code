    string path = "C:\\Users\\gaurav.saxena\\Desktop\\test.txt";
    string[] lines = File.ReadAllLines(path);
	  
	var users = new List<string>();
	var scores = new List<int>();
	foreach (string line in lines)
	{
	   string[] keyValue = line.Split(' ');
	   users.Add(keyValue[0]);
	   scores.Add(int.Parse(keyValue[1]));
    }
    Array.Sort(users);
    Array.Sort(scores);
