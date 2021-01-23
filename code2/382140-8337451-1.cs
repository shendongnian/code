	Random rng = new Random();
	const string vowels = "AEIOU";
	const string consonants = "BCDFGHJKLMNPQRSTVWXYZ";
	string CreatePuzzle(int vowelCount, int consonantCount){
		
		var result = new StringBuilder(vowelCount + consonantCount);
		for (int i = 0; i < vowelCount; i++) {
			result.Append(vowels[rng.Next(5)]);
		}
		for (int i = 0; i < consonantCount; i++) {
			result.Append(consonants[rng.Next(21)]);
		}
		
		return result.ToString();
	}
