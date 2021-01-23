        public static string[] SplitIntoNumbers(this string str)
        {
            var lines = str.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var columns = lines
                .Select(x => x.InSetsOf(3).Select(y => new string(y.ToArray())).ToList())
                .ToList();
            var numbers = Enumerable.Range(0, columns[0].Count)
                .Select(x => columns[0][x] + columns[1][x] + columns[2][x])
                .ToArray();
            return numbers;
        }
