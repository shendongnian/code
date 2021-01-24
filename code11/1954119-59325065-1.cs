    public static object SolveBlanks(object number)
            {
                object answer = number.ToString();
                if (answer == "")
                {
                    answer = DBNull.Value;
                }
                return answer;
            }
