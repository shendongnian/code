      internal class ListOfStringEqualityComparer : IEqualityComparer<List<string>>
            {
                public bool Equals(List<string> b1, List<string> b2)
                {
                    if (b1.Count != b2.Count) return false;
                    for (int i = 0; i < b1.Count; i++)
                    {
                        if (b1[i] != b2[i]) return false;
                    }
                    return true;
                }
    
                public int GetHashCode(List<string> b2)
                {
                    int hCode = 0;
                    for (int i = 0; i < b2.Count; i++)
                    {
                        hCode = EqualityComparer<string>.Default.GetHashCode(b2[i]);
                    }
                    return hCode.GetHashCode();
                }
            }
