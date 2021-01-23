    public class Question`
    {
        // some class implementation
    
        public static explicit operator Question(Post p)
        {
            return new Question { Text = p.PostText };
        }
    }
