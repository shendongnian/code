    public static void Main()
		{
			//Make an array of the possible sentence enders. Doing this pattern lets us easily update
			// the code later if it becomes necessary, or allows us easily to move this to an input
			// parameter
			string[] SentenceEnders = new string[] {"$", @"\.", @"\?", @"\!" /* Add Any Others */};
			string WhatToFind = "a"; //What are we looking for? Regular Expressions Will Work Too!!!
			string SentenceToCheck = "This, but not to exclude any others, is a sample."; //First example
			string MultipleSentencesToCheck = @"
			Is this a sentence
			that breaks up
			among multiple lines?
			Yes!
			It also has
			more than one
			sentence.
			"; //Second Example
			
			//This will split the input on all the enders put together(by way of joining them in [] inside a regular
			// expression.
			string[] SplitSentences = Regex.Split(SentenceToCheck, "[" + String.Join("", SentenceEnders) + "]", RegexOptions.IgnoreCase);
			
			//SplitSentences is an array, with sentences on each index. The first index is the first sentence
			string FirstSentence = SplitSentences[0];
			
			//Now, split that single sentence on our matching pattern for what we should be counting
			string[] SubSplitSentence = Regex.Split(FirstSentence, WhatToFind, RegexOptions.IgnoreCase);
			
			//Now that it's split, it's split a number of times that matches how many matches we found, plus one
			// (The "Left over" is the +1
			int HowMany = SubSplitSentence.Length - 1;
			
			System.Console.WriteLine(string.Format("We found, in the first sentence, {0} '{1}'.", HowMany, WhatToFind));
			
			//Do all this again for the second example. Note that ideally, this would be in a separate function
			// and you wouldn't be writing code twice, but I wanted you to see it without all the comments so you can
			// compare and contrast
			
			SplitSentences = Regex.Split(MultipleSentencesToCheck, "[" + String.Join("", SentenceEnders) + "]", RegexOptions.IgnoreCase | RegexOptions.Singleline);
			SubSplitSentence = Regex.Split(SplitSentences[0], WhatToFind, RegexOptions.IgnoreCase | RegexOptions.Singleline);
			HowMany = SubSplitSentence.Length - 1;
			
			System.Console.WriteLine(string.Format("We found, in the second sentence, {0} '{1}'.", HowMany, WhatToFind));
		}
