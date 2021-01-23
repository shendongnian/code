    public class Post { }
    public class Question : Post { }
    public class Banana { }
    static class Program {
        public static void Main(params string[] args) {
            Post p = new Question();
            Question q = (Question)p; // p IS a Question in this case
            Banana b = (Banana)p; // this does not compile
        }
    }
