       class Program
        {
        
            static void Main(string[] args)
            {
                string path1 = "D:\\test.mp3";
                string path2 = "D:\\1.mp4";
                play(path1);
                play(path2);
                Console.ReadKey();
            }
            static  void play(string audioPath)
            {
                MediaPlayer myPlayer = new MediaPlayer();
                myPlayer.Open(new System.Uri(audioPath));
                myPlayer.Play();
            }
        }
