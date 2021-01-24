    for(int i = 0; i < testArray.Length; i++)
			{
				int[] scores = new int[5];
				Console.WriteLine("Student First Name: ");
				String studentFirst = Console.ReadLine();
				Console.WriteLine("Student Last Name: ");
				String studentLast = Console.ReadLine();
				for (int j = 0; j < scores.Length; j++)
				{
					Console.WriteLine("Enter score: ");
					scores[j] = Convert.ToInt32(Console.ReadLine());
				}
				testArray[i] = new Tests(studentFirst, studentLast, scores);
			}
   
