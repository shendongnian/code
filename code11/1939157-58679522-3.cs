    public partial class UserLabelPage : Page
    {
        private Player FirstPlayer_Label;
        public UserLabelPage()
        {
            InitializeComponent();
            singlePlayer_Label.content = Player.FirstUser_Label.content; //singlePlayer_Lable is the x:name of the xaml object. Setting the object's content while initializing the component.
        }
    }
