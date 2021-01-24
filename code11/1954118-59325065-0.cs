    public static object SolveBlanks(object number)
            {
                string answer = number.ToString();
                if (answer == "")
                {
                    answer = DBNull.Value;
                }
                return answer;
            }
