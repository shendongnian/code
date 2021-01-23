            Int32 x = 1; 
            Int32 y = 2;
            // example of declaring a list of int32 arrays
            var list = new List<Int32[]> {
                new Int32[] {x, y}
            };
            // accessing x
            list[0][0] = 1;
            
            // accessing y
            list[0][1] = 1;
            
