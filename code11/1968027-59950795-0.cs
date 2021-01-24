    public class Box : ScriptableObject
    {
        // Inspector
        [SerializeField] private int _isBoxSold = 0;
        [SerializeField] private int _price = 6;
        [SerializeField] private Text _boxPrice;
        [SerializeField] private Image _boxImage;
        [SerializeField] private Button _buyButton;
    
        // Public readonly properties
        public int IsBoxSold => _isBoxSold;
        public int Price => _price;
    
        // For overwriting the sold and price values
        public void ApplyValues(int isSold, int price)
        {
            _isBoxSold = isSold;
            _price = price;
    
            // probably also update the texts?
            _boxPrice.text = _price.ToString("F");
        }
    }
    
