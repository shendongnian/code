	public static void ShowSound(string userInput2, string[] localPets4, string[] localSounds2)
	{
		var result =
			localPets4
				.Zip(localSounds2, (pet, sound) => new { pet, sound })
				.Where(x => x.pet == userInput2)
				.FirstOrDefault();
	
		if (result != null)
		{
			Console.WriteLine($"{result.pet} makes the sound {result.sound}");
			Console.WriteLine();
		}
		else
		{
			Console.WriteLine($"Sorry, {userInput2} isn't in our list of animals");
		}
	}
