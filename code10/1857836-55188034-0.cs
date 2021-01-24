		Console.Write("lesson: ");
		string lesson = Console.ReadLine();
		Console.Write("number of students: ");
		int numStudents = int.Parse(Console.ReadLine());
		Console.WriteLine("\n");
		string[] names = new string[numStudents];
		int[] grade = new int[numStudents];
		for (int i = 0; i < numStudents; i++) { // declare the loop variable here
			Console.Write("name? ");
			names[i] = Console.ReadLine();
			Console.Write("grade? ");
			grade[i] = int.Parse(Console.ReadLine());
			sum += grade[i]; // i presume you don't want to do grade[0] but rather grade[i]
		}
		average = sum / numStudents; // I presume you don't want this line inside the for-loop, if you expect the average to be properly calculated
		//foreach (string item in names) // there was a semi-colon here by mistake, which should not be there
		for (int i = 0; i < numStudents; ++i) // you want to loop over the index
		{
			Console.WriteLine($"The grade of {names[i]} is {grade[i]}"); // i was outside the square brackets like grade[]i 
		}
	}
