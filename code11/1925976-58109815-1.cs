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
**Option 2:**  Make Responses static
Response.cs
csharp
using System.Linq;
using System.Collections.Generic;
public static class Responses
{
	//bot name
	static string nomber = "Jarvis";
	static List<string> answer = new List<string>(){
		$"Mi nomber ta {nomber}",
		"Mi ta bon"
	};
	public static void AddToList(string value){
		this.answer.Add(value);
	}
	public static string Answer(int id)
	{
		return answer.ElementAt(id);
	}
}
Output.cs
csharp
using System;
public class Output
{
	public void Return(int respondType, int respond)
	{
		switch(respondType)
		{
			case 0:
				Console.WriteLine(Responses.Answer(respond));
				break;
			default:
				Console.WriteLine("Mi no ta kompronde");
				break;
		}
	}
}
Interperter.cs
csharp
using System.Collections.Generic;
using System.Linq;
public class Interpreter
{
	public int UserInputType(string value)
	{
		// Turns the user input into an array of words
		string[] words = value.Split(' ');
		int returnValue = 2;
		//int match = 0;
		Responses.AddToList("1");
		//This stores the correct response to the given question
		//var element = new List<int>(); 
		foreach(var word in words)
		{
			// if(!string.IsNullOrWhiteSpace(word))
			// {
				foreach(var listOfQuestions in userInputedQuestions)
				{
					//Convert words in the listOfQuestions to array string to match them with the userInputedQuestion
					string[] listOfQWords = listOfQuestions.Split(" ");
					
					//Check how many words matches the predefined list of questions
					foreach(var qWord in listOfQWords){
						if(word == qWord){
							returnValue = 0;
						}
					}
	
				}
			
			}
		// }
		return returnValue;
	}
	private List<string> userInputedQuestions = new List<string>(){
		"Ki ta bo nomber?",
		"Konta ku bo?"
	};
}
Hope it helps
