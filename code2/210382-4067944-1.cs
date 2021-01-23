     public static class A
            {
                public static int Num = 1;
                public int GetClassNum<T>(T inn) where T : A  // Error here
                {
                    inn. /// no Num
                   
                }
            }
