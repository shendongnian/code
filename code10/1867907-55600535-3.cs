    [Table("UserCurrWorkout")]
    public partial class UserCurrWorkout
    {
        [Key]
        public int UCWId { get; set; }
        public int UserId { get; set; }
        public int UserActiveWorkout { get; set; }
        public virtual User User { get; set; }
        public int WorkoutExerciseId { get; set; } // The explicit foreign key
        public virtual WorkoutExercise WorkoutExercise { get; set; }
    }
