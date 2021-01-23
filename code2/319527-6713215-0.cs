	class Person
	{
		Person friend = new Person();
		public void GetPencil()
		{
			bool pencilFound = 
				friend.AskQuestion(this, "Can I borrow your pencil?")
				.ToLower().Contains("yes");
		}
		public string AskQuestion(Person enquirer, string question)
		{
			// Analyze question implications.
			return "Decision made.";
		}
	}
