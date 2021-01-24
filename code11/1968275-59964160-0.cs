    public class Test 
    {
	   public string login_user_name {get; set;}
	   public string login_user_id { get; set;}
    }
    string js =  "[{\"login_user_name\":\"Rahul\",\"login_user_id\":\"43\"}]";
    var result  =  JsonConvert.DeserializeObject<List<Test>>(js);
    foreach(var ob in result)
	{
	  Console.WriteLine(ob.login_user_name);
	  Console.WriteLine(ob.login_user_id);
	}
