c#
        static public bool Solve(int[][] bo)
        {
            int x;
            int y;
            if (FindEmpty(bo) == (100, 100))
            {
                return true;
            }
            else
            {
                y = FindEmpty(bo).Item1;
                x = FindEmpty(bo).Item2;
            }
-            for (int i = 0; i < 10; i++)
+            for (int i = 1; i < 10; i++)
            {
                if (IsValid(bo, i, x, y) == true)
                {
                    bo[y][x] = i;
                    if (Solve(bo) == true)
                    {
                        return true;
                    }
                    else
                    {
                        bo[y][x] = 0;
                    }
                }
            }
            return false;
        }
At some point `IsValid(bo, 0, x, y)` returns true, so you replace the zero with another zero forever.
