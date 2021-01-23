        class TestSong
        { 
          public static void Main(String[] Args)
          {
              Song _song = new Song(); //create an object for class 'Song'    
              _song.Author_Name = 'John Biley';
              String author = _song.Author_Name;           
              Console.WriteLine("Authorname = {0}"+author);
          }
        }
