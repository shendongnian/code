 List<String> l = new List<string>(){
//your items here
};
Dictionary<string, int> map = new Dictionary<string, int>();
foreach(string i in l)
{
if (!map.ContainsKey(i)) { map.Add(i, 0); }
else{
  map[i] =map[i] + 1;
 }
}    
