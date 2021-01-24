    static int CountCorrect(int[] pc, int[] user)
            {
                int count = 0;
                for (int i = 0; i < user.Length; i++)
                {
                    if (DoesExists(pc, user[i]))
                    {
                        count++;
                    }
                }
    
                return count;
            }
