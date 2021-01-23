    static double SumDoubleObjects(params Object[] objs)
        {
            double sum = 0;
            foreach (object curr in objs)
            {
                sum += (double)curr;
            }
            return sum;
        }
