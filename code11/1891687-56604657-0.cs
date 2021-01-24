public class MyModel {
    public string Menu1 { get; set; }
    public string Menu2 { get; set; }
    public List<int> Menu3 { get; set; }
    public string Menu4 { get; set; }
    public List<string> Menu5 { get; set; }
}
Then, in the class you receive your JSON string:
    var myObj = JsonConvert.DeserializeObject<MyModel>(jsonString);
    // Access any property through myObj object
    var menu1 = myObj.Menu1;
