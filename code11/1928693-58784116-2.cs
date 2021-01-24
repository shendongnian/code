        private static IEnumerable<string> ReadLineValues(string sourceLine, List<int> colsPositions)
        {
            for (int colId = 0; colId < colsPositions.Count; colId++)
            {
                var start = colsPositions[colId];
                int length;
                if (colId < colsPositions.Count - 1)
                    length = colsPositions[colId + 1] - start;
                else
                    length = sourceLine.Length - start;
                if (start < sourceLine.Length)
                {
                    if (start + length > sourceLine.Length)
                        length = sourceLine.Length - start;
                    yield return sourceLine.Substring(start, length).Trim();
                }
            }
        }
