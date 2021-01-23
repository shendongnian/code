    public void backtrack (double sum, String solution, ArrayList numbers, int depth, double targetValue, int j)
    {
        for (int i = j; i < numbers.Count; i++)
            {
                double potentialSolution = Convert.ToDouble(arrayList[i] + "");
                if (sum + potentialSolution > targetValue)
                    continue;
                else if (sum + potentialSolution == targetValue)
                {
                    if (depth == 0)
                    {
                        solution = potentialSolution + "";
                        /*Store solution*/
                    }
                    else
                    {
                        solution += "," + potentialSolution;
                        /*Store solution*/
                    }
                }
                else
                {
                    if (depth == 0)
                    {
                        solution = potentialSolution + "";
                    }
                    else
                    {
                        solution += "," + potentialSolution;
                    }
                    backtrack (sum + potentialSolution, solution, numbers, depth + 1, targetValue, i + 1);
                }
            }
    }
