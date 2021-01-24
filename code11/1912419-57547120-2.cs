        public static void LineDiagonal(int x, int y, int length)
        {
            for(int i = 0; i < length; i++)
            {
                //This will set your cursor position on x and y
                Console.SetCursorPosition(x+i, y+i);
                //This will draw '-' n times here n is length
                Console.Write(@"\");
            }
        }
