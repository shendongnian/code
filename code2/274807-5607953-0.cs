        public static void Pairwise(Body[] b, int n) {
            if (n >= b.Length) n = b.Length-1;
            for (int i = 0; i < n; i++) {
                Body b2 = b[i];
                for (int j = i + 1; j < n; j++)
                    b2.Pairwise(b[j]);
            }
        }
