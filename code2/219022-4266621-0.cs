    private bool IsEqualLists(List<string> A, List<string> B)
    {
        for(int i = 0; i < A.Count; i++)
        {
            if(i < B.Count - 1) {
                return false; }
            else 
            {
                if(!String.Equals(A[i], B[i]) {
                    return false;
                }
            }
        }
        return true;
    }
