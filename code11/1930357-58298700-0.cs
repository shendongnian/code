        for (int i = 1; i <= n; i++)
        { 
                if (i % 3 == 0 || i % 5 == 0)
                {
                        if (numbers.Length > 0)
                                numbers.Append(", ");        
                        numbers.Append(i);
                }
        }
