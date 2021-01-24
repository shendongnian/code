    public partial class UserControlRotator : UserControl
    {
        public UserControlRotator()
        {
            InitializeComponent();
        }
        static List<int> list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 }; // 9
        public static int countSAO = list.Count;
        public static int MyCountSAOValue()
        {
            return list.Count;
        }
    }
