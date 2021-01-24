     int pheonixamount = int.Parse(Console.ReadLine());
     List<Phoenix> phoenixes = new List<Phoenix>();
     for (int i = 0; i < pheonixamount; i++) {
       Phoenix bird = new Phoenix(
         double.Parse(Console.ReadLine()),
         double.Parse(Console.ReadLine()), 
         double.Parse(Console.ReadLine())
       );
       phoenixes.Add(bird);
     }   
