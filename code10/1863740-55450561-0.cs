    public static class AdvancedCollectionViewEx
    {
        public static void GetTopRang(this AdvancedCollectionView acv, int Range)
        {
            do
            {
                var LastIndex = acv.Source.Count - 1;
                acv.Source.RemoveAt(LastIndex);
    
            } while (acv.Source.Count > Range);
        }
    }
