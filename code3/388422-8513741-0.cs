    public static ExamProduced GetExamProduced(XElement xml) {
        var examProduced = new ExamProduced
		{
			ExamID = (int)xml.Attribute("ExamID"),
			Date = (DateTime)xml.Attribute("Date"),
			Seed = (int)xml.Attribute("Seed"),
			Exercises = GetExercises(xml)
		};
		
        return examProduced;
    }
    public static List<Exercise> GetExercises(XElement xml) {
        var objs = 
            from objective in xml.Descendants("Objective")
			where (bool)objective.Attribute("Produced")
			let id = (int)objective.Attribute("ID")
			select new Exercise
                {
					ExerciseID = id,
					IsMakeUp = (bool)objective.Attribute("MakeUp"),
					Quantity = (int)objective.Attribute("Quantify"),
					Score = (int)objective.Elements().Last().Attribute("Result"),
					Answers = GetAnswers(xml, id)
				};
				
            return objs.ToList();
    }
    public static List<Answer> GetAnswers(XElement xml, int objectiveId) {
        var answers = 
                from answer in xml.Descendants("Answer")
				where (int)answer.Attribute("ObjectiveID") == objectiveId
				select new Answer
                  {
					IsCorrect = (bool)answer.Attribute("IsCorrect")
				  };
        return answers.ToList();
    }
