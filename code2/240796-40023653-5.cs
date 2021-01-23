    /// <summary>
        /// For a given source code, it parses all regions and creates a dictionary where 
        /// Key=region name and Value=list of region's code lines.<para />
        /// Known Issue: This method dos not work with regions within regions. <para />
        /// </summary>
        /// <param name="sourceCodeFileName">string - full source code .cs path</param>
        /// <returns>Key=region name and Value=list of region's code lines.</returns>
        public static Dictionary<string, List<string>> GetRegionsFromCShapFile(string sourceCodeFileName)
        {
            FileInfo f = new FileInfo(sourceCodeFileName);
            if (f.Length > ONE_Gb)
            {
                throw new ArgumentOutOfRangeException(string.Format("File:{0} has size greater than {1}{2}", MAX_STORAGE, STORAGE_UNIT));
            }
            Dictionary<string, List<String>> regions = new Dictionary<string, List<string>>();
            string[] readLines = File.ReadAllLines(sourceCodeFileName);
            List<string> current_list = null;
            
            foreach (string l in readLines)
            {
                if (l != null)
                {
                    if (l.TrimStart().StartsWith("#region", StringComparison.CurrentCultureIgnoreCase))
                    {
                        string key = string.Format("{0}.cs", ExtractNumber(l.Trim()));
                        if (regions.ContainsKey(key))
                        {
                            throw new ArgumentException(string.Format("Duplicate named regions detected: {0}", l.Trim()));
                        }
                        regions[key] = new List<string>();
                        current_list = regions[key];
                    }
                    else
                    {
                        if (current_list != null) //ignores code read if it is not within a region
                        {
                            if (l.TrimStart().StartsWith("#endregion", StringComparison.CurrentCultureIgnoreCase))
                            {
                                current_list = null; //stops using the current list
                            }
                            else
                            {
                                //use current list
                                current_list.Add(l);
                            }
                        }
                    }
                }
            }
            return regions;
        }
