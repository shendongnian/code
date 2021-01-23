          String sourcestring = "-dog--cat--d--";
          Regex re = new Regex(@"\w+");
          MatchCollection mc = re.Matches(sourcestring);
          int mIdx=0;
          foreach (Match m in mc)
           {
            for (int gIdx = 0; gIdx < m.Groups.Count; gIdx++)
              {
                Console.WriteLine("[{0}][{1}] = {2}", mIdx, re.GetGroupNames()[gIdx], m.Groups[gIdx].Value);
              }
            mIdx++;
          }
