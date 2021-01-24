cs
using System;
namespace MatrixCount
{
    class Program
    {
        enum Directions { Right, Up, Left, Down }
        static void Main()
        {
            do
            {
                Console.WriteLine("Enter Number Of Rows and Colums!");
                uint Rows = uint.Parse(Console.ReadLine());
                uint Colums = uint.Parse(Console.ReadLine());
                uint TotalCells = Rows * Colums;
                uint Shifts;
                bool InvalidInput;
                do
                {
                    Console.WriteLine("Enter Number of Shiftings!");
                    Shifts = uint.Parse(Console.ReadLine());
                    InvalidInput = Shifts > TotalCells;
                    if (InvalidInput)
                    {
                        Console.WriteLine("Invalid shiftings!");
                    }
                } while (InvalidInput);
                Directions Direction = Directions.Right;
                int R = 0;
                int C = 0;
                uint BoundaryLeft = 0;
                uint BoundaryBottom = Rows - 1;
                uint BoundaryRight = Colums - 1;
                uint BoundaryTop = 0;
                for (int i = 0; i < Shifts; i++)
                {
                    bool Shifted = false;
                    while (!Shifted)
                    {
                        switch (Direction)
                        {
                            case Directions.Right:
                                if (C + 1 > BoundaryRight)
                                    Direction = Directions.Down;
                                else
                                {
                                    C++;
                                    Shifted = true;
                                }
                                break;
                            case Directions.Down:
                                if (R + 1 > BoundaryBottom)
                                    Direction = Directions.Left;
                                else
                                {
                                    R++;
                                    Shifted = true;
                                }
                                break;
                            case Directions.Left:
                                if (C - 1 < BoundaryLeft)
                                    Direction = Directions.Up;
                                else
                                {
                                    C--;
                                    Shifted = true;
                                }
                                break;
                            case Directions.Up:
                                if (R - 2 < BoundaryTop)
                                {
                                    Direction = Directions.Right;
                                    BoundaryLeft++;
                                    BoundaryBottom--;
                                    BoundaryRight--;
                                    BoundaryTop++;
                                }
                                else
                                {
                                    R--;
                                    Shifted = true;
                                }
                                break;
                        }
                    }
                }
                Console.WriteLine("You end up at ({0}, {1})!", R, C);// add 1 to r and c if you  want to be a mathematician
                Console.WriteLine("Again?");
            }
            while (Console.ReadLine().ToUpper() == "YES");
        }
    }
}
