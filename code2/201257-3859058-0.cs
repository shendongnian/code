    private static void DrawABox( int x, int y, int width, int height,char Edge )
            {
                Console.SetCursorPosition(x, y);
                for ( int h_i = 0; h_i <= height ; h_i++ )
                {
                    for ( int w_i = 0; w_i <= width; w_i++ )
                    {
                        
                        if ( h_i % height == 0 || w_i % width == 0 )
                        {
                            Console.SetCursorPosition(x + w_i, y + h_i);
                            Console.Write(Edge);
                        }
    
                       
                    }
                    
                }
            }
