    public static class ListExtension
    {
        public static void InitializeImageArray(this List<string> items, int start,int end)
        {
            for (int i = start; i <= end; i++)
            {
                items.Add($"images{i}.png");
            }
        }
        public static string GetImageFileName(this List<string> items, int index)
        {
            return items[index];
        }
    }
