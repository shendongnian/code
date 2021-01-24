string MAC = "00122345"
//The List that keeps the pairs
List<string> MACList = new List<string>();
//Checks the input string to be an even number 
if(MAC.Length % 2 == 0)
{
	//Split the even number into pairs
	for (int i = 1 ; i <= MAC.Length; i++)
	{
		//When it is in even index it splits
	    if(i % 2 == 0)
		{
			MACList.Add(MAC.Substring(i - 2, 2));
		}
	}
}
//Make the preferable output
string output = "";
for(int j = 0; j < MACList.Count; j++)
{
	output = output + MACList[j] + ":";
}
output = output.Trim(output.Last());
//input : 00122345
//output : 00:12:23:45
