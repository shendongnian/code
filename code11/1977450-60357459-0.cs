            Console.SetBufferSize(17, 17);
            //Console.CursorVisible = false;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                    Console.Write(x.ToString("X"));
                Console.Write("\n");
            }
