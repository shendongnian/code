    while (true)
       {
          keyInfo = Console.ReadKey(true);
          Console.Clear();
          switch (keyInfo.Key)
          {
             case ConsoleKey.UpArrow:
             if (m.Y > 0)
             {
                m.Y--;
             }
             break;
             case ConsoleKey.DownArrow:
             if (m.Y < MaxY)
             {
                m.Y++;
             }
             break;
             }
          }
          m.Draw();
          s.X = m.X + 100;
          s.Y = m.Y;
          s.Draw(); //i think is better to put draw functions outside switch(key)
       }
