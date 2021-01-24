        public int[] Search(string targetName, string fileName)
        {
            List<string> file_text = File.ReadAllLines("Files/Exercise_Files/SSA_Names_Long.txt").ToList();
            List<string> matching_lines = file_text.Where(w => w == targetName).ToList();
            List<int> nums = new List<int>();
            foreach (string test_line in matching_lines)
            {
                nums.Add(file_text.IndexOf(test_line));
            }
            return nums.ToArray();
        }
