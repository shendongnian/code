    [Serializable]
    public class PlayerData 
    {
        public int coinsAmount;
        [SerializeField] private List<Box> _boxes;
        // Example: run through all boxes and update their texts
        public void UpdateBoxes()
        {
            foreach(var box in _boxes)
            {
                box.BoxPrice.text = box.Price.ToString();
            }
        }
    }
