        private void Evaluate(ulong n)
        {
            ulong f = 255;
            int r = 0, p = -1;
            for (int i = 0; i < 8; i++)
            {
                r >>= 1;
                var t = n & f;
                if (t > 0)
                {
                    r += 128;
                    if (p < 0)
                        p = i;
                }
                f <<= 8;
            }
            Console.WriteLine($"Resulting byte: {r}");
            Console.WriteLine($"Position: {p}");
        }
