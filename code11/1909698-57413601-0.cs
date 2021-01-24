			List<Coordinates> hp_List = new List<Coordinates>
            {
                new Coordinates
                {
                     x = 1,
                     y = 2,
                     z = 3
                },
                new Coordinates
                {
                     x = 4,
                     y = 5,
                     z = 6
                }
            };
            int R = hp_List.Count();
            float[,,] hp_array = new float[R, 1, 3];
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    hp_array[i, j, 0] = hp_List[j].x;
                    hp_array[i, j, 1] = hp_List[j].y;
                    hp_array[i, j, 2] = hp_List[j].z;
                }
            }
            Console.WriteLine(string.Format("X Y Z"));
            for (int i =  0; i< R; i++)
            {
                Console.WriteLine(string.Format("{0} {1} {2}", hp_array[i, 0, 0], hp_array[i, 0, 1], hp_array[i, 0, 2]));
            }
            Console.Read();
