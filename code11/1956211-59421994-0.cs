    public class Score
    {
        public static int Highscore;
    }
   
    class Scene1
    {
        static void Main(string[] args)
        {
           if (Input.GetKeyDown(KeyCode.F1)||
               Input.GetKeyDown(KeyCode.F2)||
               Input.GetKeyDown(KeyCode.F3)||
               Input.GetKeyDown(KeyCode.F4)||
                 ...){
                       Score.Highscore = 5;
                       Console.WriteLine("Highscore: " +  Score.Highscore);
                       SceneManager.LoadScene(0);
                     }
    //Output is = 5
        }
    }
class Scene2
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Highscore: " +  Score.Highscore);
           //Output will still be 5
        }
    }
    ```
