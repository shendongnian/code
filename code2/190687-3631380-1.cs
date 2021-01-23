    public class Box
    {
        // ...
        public IEnumerable<Box> GetBoxes() 
        {
            yield return this;
            for (int i=0; i<box.ChildrenCount; i++)
            {
                foreach (Box child in box.GetChild(i).GetBoxes())
                {
                     yield return child;
                }
            }
        }
    }
