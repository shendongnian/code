         There is no library for getting inverse mod, but the following code can be used to get it.
          //Given a and b->ax+by=d
            long[] u = { a, 1, 0 };
            long[] v = { b, 0, 1 };
            long[] w = { 0, 0, 0 };
            long temp = 0;
            while (v[0] > 0)
            {
                double t = (u[0] / v[0]);
                for (int i = 0; i < 3; i++)
                {
                    w[i] = u[i] - ((int)(Math.Floor(t)) * v[i]);
                    u[i] = v[i];
                    v[i] = w[i];
                }
            }
         //u[0] is gcd while u[1] gives x and u[2] gives y. 
          //if u[1] gives the inverse mod value and if it is negative then the following gives the first positive value
           if (u[1] < 0)
                {
                    while (u[1] < 0)
                    {
                        temp = u[1] + b;
                        u[1] = temp;
                    }
                }
