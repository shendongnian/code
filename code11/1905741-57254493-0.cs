JSON
[{"cols": [
 {
 "name": "A",
 "key": 0
 },{
 "name": "B",
 "key": 
 },{
 "rows": [
 [
 "Example",
 "1234abcd\r\n(sample)"
 ],
 [
 "example1 ",
 "17 18"
 ]
 ]
 }
 ]
i used your json in request to create output on each step:
C#
string j1 = File.ReadAllText("c:\\1\\json.txt");
	var r = JsonConvert.DeserializeObject<List<parentJson>>(j1);
	var obj = JsonConvert.DeserializeObject<jparced>(r.FirstOrDefault().json);
	Console.Write(obj.files);
and classes:
C#
public class parentJson{
	public string sample1 {get;set;}
	public string json {get;set;}
	
	public parentJson(){}
}
public class jparced
{
	public string number { get; set; }
	public string files {get;set;}
	
}
