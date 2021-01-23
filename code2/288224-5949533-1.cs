    using System.Text.RegularExpressions;
    
    class Program
    {
            static IEnumerable<int> getBuildVersions(string BuildVersion)
            {
                string[] BuildVersionParts = BuildVersion.Split('.');
                foreach (string part in BuildVersionParts)
                {
                    yield return int.Parse(part);
                }
            }
    
            static T[] HierarchicalMax<T>(IEnumerable<T[]> items)
            {
                var length = items.Min(v => v.Length);
                IEnumerable<T[]> result = items;
    
                for (int i = 0; i < length; i++)
                {
                    int offset = i;
                    result = result.OrderByDescending(v => v[offset]);
                }
    
                T[] max = result.FirstOrDefault();
    
                return max;
            }
    
            static void Main(string[] args)
            {
                string data = @"
                    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.001
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.002
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.003
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.004
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.005
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.006
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.006
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.006
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.007
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.008
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.009
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.010
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.011
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.012
    sinsscm01:/mobile/6.70_Extensions/6.70.102/ANT_SASE_RELEASE_6.70.102.013
    ";
                List<int[]> BuildVersions = new List<int[]>();
    
                Regex rx = new Regex(@"\d+\.+\d+\.+\d+\d+\.+\d+");
                
                foreach (Match m in rx.Matches(data))
                {                
                    BuildVersions.Add(getBuildVersions(m.Value).ToArray());                
                }
    
                foreach (int[] version in BuildVersions)
                {
                    Console.WriteLine(version[0].ToString() + " " + version[1].ToString() + " " + version[2].ToString() + " " + version[3].ToString());
                }
    
                int[] maxVersion = HierarchicalMax<int>(BuildVersions);
    
                Console.WriteLine("MaxVersion is ");
                Console.WriteLine(maxVersion[0].ToString() + " " + maxVersion[1].ToString() + " " + maxVersion[2].ToString() + " " + maxVersion[3].ToString());
    
                Console.ReadLine();
            }
     }
