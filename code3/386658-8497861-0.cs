        public int LineFromPos(string S, int Pos)
        {
            int Res = 1;
            for (int i = 0; i <= Pos - 1; i++)
                if (S[i] == '\n') Res++;
            return Res;
        }
