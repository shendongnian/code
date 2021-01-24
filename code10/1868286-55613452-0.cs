    List<int> usedNumbers = new List<int> ();
		for (int i = 0; i < Position.Length; i++)
		{
			do
			{
				number = Position[Random.Range (0, Position.Length)];
			} while (usedNumbers.Contains (number));
			//You have your unique number here.
			sprites[i].transform.position = new Vector3 (Position[number], 0f, 0f);
			//Do not forget to store your number in usedNumbersList.
			usedNumbers.Add (number);
		}
