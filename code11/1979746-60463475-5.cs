//The List that keeps the pairs
List<string> MACList = new List<string>();
//Split the even number into pairs
for (int i = 1; i <= MAC.Length; i++)
{				
	if (i % 2 == 0)
	{
		MACList.Add(MAC.Substring(i - 2, 2));
	}
}
//Make the preferable output
string output = "";
for (int j = 0; j < MACList.Count; j++)
{
	output = output + MACList[j] + ":";
}
//Checks if the input string is even number or odd number
if (MAC.Length % 2 == 0)
{
	output = output.Trim(output.Last());
}
else
{
	output += MAC.Last();
}
//input : 00122345
//output : 00:12:23:45
//input : 0012234
//output : 00:12:23:4
