        ...
        for (int i = 1; i <= n; i++)
        { 
                if (i % 3 == 0 || i % 5 == 0)
                {
                        // Add comma (if required) first...
                        if (numbers.Length > 0)
                                numbers.Append(", ");        
                        // ...and only then value
                        numbers.Append(i);
                }
        }
        ...
