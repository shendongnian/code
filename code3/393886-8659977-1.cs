        private List<string> GetCol()
        {
            var x = Enumerable.Range(65, 26).Select(p => (char)p).ToList();
            List<string> result = new List<string>();
            foreach (var first in x)
            {
                result.Add(first.ToString());
            }
            foreach (var first in x)
            {
                foreach (var second in x)
                {
                    result.Add(first.ToString() + second.ToString());
                }
            }
            return result;
        }
