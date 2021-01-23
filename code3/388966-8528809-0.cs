    public EntityCollection<Exercise> GetExercises(XElement xml)
    {
        var objs =
            from objective in xml.Descendants("Objective")
            where (bool)objective.Attribute("Produced")
            let id = (int)objective.Attribute("ID")
            select new Exercise
            {
                ExerciseID = id,
                MakeUp = (bool)objective.Attribute("MakeUp"),
                Quantify = (byte)(int)objective.Attribute("Quantify"),
                Score = (float)objective.Elements().Last().Attribute("Result")
            };
        var entityCollection = new EntityCollection<Exercise>();
        foreach(var exercise in objs) {
            entityCollection.Add(exercise);
        }
        return entityCollection;
    }
