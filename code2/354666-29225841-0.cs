    unsafe void Mutate(string s, string newContents)
    {
        System.Diagnostics.Debug.Assert(newContents.Length == s.Length);
        fixed (char* ps = s)
        {
            for (int i = 0; i < newContents.Length; ++i)
            {
                ps[i] = newContents[i];
            }
        }
    }
