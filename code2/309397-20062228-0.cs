        private static Regex ALL_Z_REGEX = new Regex("^[zZ]+$");
        static string GetNextColumn(string currentColumn)
        {
            // AZ would become BA
            char lastPosition = currentColumn[currentColumn.Length - 1];
            if (ALL_Z_REGEX.IsMatch(currentColumn))
            {
                string result = String.Empty;
                for (int i = 0; i < currentColumn.Length; i++)
                    result += "A";
                return result + "A";
            }
            else if (lastPosition == 'Z')
                return GetNextColumn(currentColumn.Remove(currentColumn.Length - 1, 1)) + "A";
            else
                return currentColumn.Remove(currentColumn.Length - 1, 1) + (++lastPosition).ToString();
        }
