csharp
using System.Linq;
using System.Collections.Generic;
public class Responses
{
    private static Responses _instance = new Responses();
    public static GetInstance() {
       return _instance;
    }
	//bot name
	static string nomber = "Jarvis";
	List<string> answer = new List<string>(){
		$"Mi nomber ta {nomber}",
		"Mi ta bon"
	};
	public void AddToList(string value){
		this.answer.Add(value);
	}
	public string Answer(int id)
	{
		return answer.ElementAt(id);
	}
}
Then change on other files
csharp
//from
var responses = new Responses();
//to
var responses = Responses.GetInstance();
//from
responses.answer.Add()
//to
reponses.AddToList()
Hope it helps
