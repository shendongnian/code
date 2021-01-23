    public class Keyboarding
    {
        [XmlArray("Exercises")]
        [XmlArrayItem("Exercise")]
        public Collection<Exercise> UnprocessedExercises { get; set; }
        public Keyboarding()
        {
            UnprocessedExercises = new Collection<Exercise>();
            UnprocessedExercises.Add(new StandardExercise());
        }
    }
    [XmlInclude(typeof(StandardExercise))]
    public class Exercise
    {
    }
    [Serializable]
    public class StandardExercise : Exercise
    {
    }
