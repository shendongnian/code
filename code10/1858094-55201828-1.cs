    public class Program
    {
	    public static void Main()
	    {
		   string jsonData = "{ \"achievementsOneTime\": [ \"supersmash_tinman_challenge\", [], \"blitz_kill_without_kit\"] }";
		   var responseDeserialized = JsonConvert.DeserializeObject<Achievements>(jsonData);
		   Console.WriteLine("Deserialized response is ::");
		
		   int index = 0;
           foreach (var item in responseDeserialized.achievementsOneTime)
           {
              PrintAchievementsOneTime(item, index);
		      index++;
           }
	     }
	
	     private static void PrintAchievementsOneTime(Object achievementsOneTime, int index) {
		     Console.WriteLine("Item at index " + index + " type is : " + achievementsOneTime.GetType().Name + ". Value is : " + achievementsOneTime);
	    }
    }
    public class Achievements {
	     public Object[] achievementsOneTime;
    }
