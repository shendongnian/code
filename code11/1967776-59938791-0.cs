          public static bool IsSub(List<string> a, List<string> b)
            {
                if (a == null && b != null)
                    return false;
                if (a != null && b == null)
                    return true;
                int ib = 0;
                for (int ia = 0; ia < a.Count; ia++)
                {
                    if (a[ia] == b[ib])
                        ib++;
                    if (ib == b.Count)
                        return true;
                }
                return false;
            }
test
	List<string> a = new List<String>() {
	  "20", "32A", "50K", "50F", "50D", "70", "72"};
	List<string> b = new List<string> {
	  "20", "32A", "72"};
	Console.Write(IsSub(a, b));
output:
true
