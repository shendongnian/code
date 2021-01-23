    public ExamProduced GetExamProduced(XElement xml, YourContext context)
    {
        var examProduced = new ExamProduced()
        {
            ExamProducedID = (int)xml.Attribute("ExamID"),
            Date = (DateTime)xml.Attribute("Date"),
            Seed = (int)xml.Attribute("Seed")
        };
        context.ExamsProduced.Attach(examProduced);
        LoadExercises(xml, context, examProduced);
        // examProduced.Exercises should be available at this point
        return examProduced;
    }
    public void LoadExercises(XElement xml, YourContext context, ExamProduced examProduced)
    {
        foreach (var exercise in
            from objective in xml.Descendants("Objective")
            where (bool)objective.Attribute("Produced")
            let id = (int)objective.Attribute("ID")
            let id2 = (Objective)entityService.Objectives.Where(o => o.ObjectiveID == id).FirstOrDefault()
            select new Exercise
            {
                ExamProduced = examProduced,
                Objective = id2,
                MakeUp = ...
                Quantify = ...
                Score = ...
            }))
        {
            context.Exercises.Attach(exercise);
        }
    }
