            List<Fraction> steps = new List<Fraction>();
           
            for (int i = 0; i < 5; i++)
            {
                if (i > 0)
                    half = whole / (whole * 2 + half);
                var step = whole + half;
                steps.Add(step);
                Console.WriteLine($"   {i + 1}: {step}");
            }
