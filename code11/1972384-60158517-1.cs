    public class GoogleAddSlot : IEnumerable<AdSlotSizes>
    {
        private readonly List<AdSlotSizes> _slotSizes = new List<AdSlotSizes>();
        public void Add(AdSlotSizes sizes)
        {
            _slotSizes.Add(sizes);
        }
        public AdSlotSizes this[int index] => _slotSizes[index];
        public IEnumerator<AdSlotSizes> GetEnumerator()
        {
            foreach (var sizes in _slotSizes)
            {
                yield return sizes;
            }
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator < AdSlotSizes > )this.GetEnumerator();
        }
    }
