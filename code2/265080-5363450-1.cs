    internal class Controller
    {
        private Gender selectedGender;
        private List<Person> allPeople;
        private List<Person> friends;
    
        public Controller(IEnumerable<Person> allPeople)
        {
            this.allPeople = new List<Person>(allPeople);
            this.friends = new List<Person>();
        }
    
        public void BindData(/* control here */)
        {
            // Code would go here to set up the data binding between
            // the friends list and the list box control
        }
    
        // Event subscriber for CheckedListBox.SelectedIndexChanged
        public void OnGenderSelected(object sender, EventArgs e)
        {
            CheckedListBox listBox = (CheckedListBox)sender;
            this.selectedGender = /* get selected gender from list box here */;
        }
    
        // Event subscriber for Button.Click
        public void OnUpdateFriends(object sender, EventArgs e)
        {
            this.friends.AddRange(
                from p in this.allPeople
                where p.Gender == this.selectedGender
                select p);
            // If you use data binding, you would need to ensure a
            // data update event is raised to inform the control
            // that it needs to update its view.
        }
    }
    
    // . . .
    
    // On initialization, you'll need to set up the event handlers, etc.
    updateFriendsButton.Click += controller.OnUpdateFriends;
    genderCheckedListBox.SelectedIndexChanged += controller.OnGenderSelected;
    controller.BindData(friendsListBox);
    // . . .
