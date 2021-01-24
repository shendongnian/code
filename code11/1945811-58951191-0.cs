csharp
var resp = await Http.GetStringAsync("/Api/Default/GetProjectsList");
var list = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Tuple<string,int>>>(resp);
foreach(var i in list){
    Console.WriteLine("--------");
    Console.WriteLine(i.Item1);
    Console.WriteLine(i.Item2);
    Console.WriteLine("--------");
}
