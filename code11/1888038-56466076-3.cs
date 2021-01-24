        List<int> multiples = getCommonMultiples(a, b_min);
        //create List to hold number of ints which are in solution
        List<int> solutions = multiples.ToList();
        foreach(int x in multiples)
        {
            foreach(int y in b)
            {
                if (y % x != 0 && solutions.Contains(x))
                {
                    solutions.Remove(x);
                    break;
                }
            }
        }
