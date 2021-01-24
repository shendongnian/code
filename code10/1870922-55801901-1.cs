    public static class DiaryExtensions
    {
        public static DiaryEntry AddEntry(this IEnumerable<DiaryEntry> diary, DiaryEntry newEntry)
        {
            ICollection<DiaryEntry> diaryList = (ICollection<DiaryEntry>)diary;
            if (newEntry != null)
                diaryList.Add(newEntry);
            return newEntry;
        }
    }
