    public partial class Form1 : Form
    {
        private readonly BingoGame _game = new BingoGame();
        public Form1()
        {
            InitializeComponent();
            _game.StartGame();
        }
    
        private void StartGameBtn_Click(object sender, EventArgs e)
        {
            _game.StartGame();
            NumbersList.Items.Clear();
            SortedList.Items.Clear();
        }
    
        private void DrawNumberBtn_Click(object sender, EventArgs e)
        {
            _game.DrawNumber();
            SetListboxItems(NumbersList, _game.GetDrawnNumbers());
            SetListboxItems(SortedList, _game.GetDrawnNumbersSorted());
        }
    
        private void SetListboxItems(ListBox listbox, IEnumerable<string> numbers)
        {
            listbox.Items.Clear();
            foreach (var item in numbers)
            {
                listbox.Items.Add(item);
            }
        }
    }
