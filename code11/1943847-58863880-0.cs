    public class ItemComparer : IComparer<Item>
    {
        public int Compare(Item x, Item y)
        {
            return Compare(x?.Id, y?.Id);
        }
        private int Compare(string first, string second)
        {
            // Rudimentary argument validation - this could be improved
            // Null check - consider null as less than non-null
            if (first == null) return second == null ? 0 : -1;
            if (second == null) return 1;
            // Number check - if fails, return string comparison
            if (!first.All(char.IsDigit) || !second.All(char.IsDigit))
                return first.CompareTo(second);
            // Length check - if fails, return int comparison
            if (first.Length < 7 || second.Length < 7)
                return int.Parse(first).CompareTo(int.Parse(second));
            // Compare years
            var result = int.Parse(first.Substring(4, 2))
                .CompareTo(int.Parse(second.Substring(4, 2)));
            if (result != 0) return result;
            // Compare months part
            result = int.Parse(first.Substring(2, 2))
                .CompareTo(int.Parse(second.Substring(2, 2)));
            if (result != 0) return result;
            // Compare days part
            result = int.Parse(first.Substring(0, 2))
                .CompareTo(int.Parse(second.Substring(0, 2)));
            if (result != 0) return result;
            // Compare incrementing number part
            return int.Parse(first.Substring(6)).CompareTo(int.Parse(second.Substring(6)));
        }
    }
