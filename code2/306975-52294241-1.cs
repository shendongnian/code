    namespace X
    {
        public class Utils
        {
            public class StrCmpLogicalComparer : IComparer<Projects.Sample>
            {
                [DllImport("Shlwapi.dll", CharSet = CharSet.Unicode)]
                private static extern int StrCmpLogicalW(string x, string y);
            
                public int Compare(Projects.Sample x, Projects.Sample y)
                {
                    string[] ls1 = x.sample_name.Split("_");
                    string[] ls2 = y.sample_name.Split("_");
                    string s1 = ls1[0];
                    string s2 = ls2[0];
                    return StrCmpLogicalW(s1, s2);
                }
            }
       
        }
    }
