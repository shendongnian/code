    Console.WriteLine("Enter first X value: ");
            float point1X = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter first Y value: ");
            float point1Y = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter second X value: ");
            float point2X = float.Parse(Console.ReadLine());
            Console.WriteLine("Enter second Y value: ");
            float point2Y = float.Parse(Console.ReadLine());
            Console.WriteLine();
        double deltaX = point2X - point1X;
        double deltaY = point2Y - point1Y;
        double distance = Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY,2));
        double angle1 = Math.Atan2(point1Y,point1X);
        double angle2 = Math.Atan2(point2Y,point2X);
        double angleT = Math.Abs(angle1 - angle2) * 180 / Math.PI;
        double point1 = point1X + point1Y;
        double point2 = point2X + point2Y;
        if (point1 + 2 == point2)
        {
            Console.WriteLine("DeltaX value is: " + deltaX);
            Console.WriteLine("DeltaY value is: " + deltaY);
            Console.WriteLine("The distance is: " + distance);
            Console.WriteLine("The angle is: 135°");
        }
        else if (point2 + 2 == point1)
        {
            Console.WriteLine("DeltaX value is: " + deltaX);
            Console.WriteLine("DeltaY value is: " + deltaY);
            Console.WriteLine("The distance is: " + distance);
            Console.WriteLine("The angle is: -135°");
        }
        else
        {
            Console.WriteLine("DeltaX value is: " + deltaX);
            Console.WriteLine("DeltaY value is: " + deltaY);
            Console.WriteLine("The distance is: " + distance);
            Console.WriteLine("The angle is: " + angleT + "°");
        }   
