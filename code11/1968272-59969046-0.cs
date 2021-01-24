    public UF_ButtonLoop()
        {
            InitializeComponent();
            //TransferListToButtone_Rev1();
            List<KeyValuePair<string, string>> MyItems = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Apple", "Green Fruit"),
                new KeyValuePair<string, string>("Orange", "Orange Fruit"),
                new KeyValuePair<string, string>("Sprout", "Spawn of the Devil"),
                new KeyValuePair<string, string>("Hershey Bar", "A bit like chocolate"),
                new KeyValuePair<string, string>("Beefburger", "Man Food")
            };
            List<Control> ListOfButtons = new List<Control>
            {
                button1, button2, button3, button4, button5, button6, button7, button8, button9, button10
            };
            void A_Button_Click(object sender, System.EventArgs e)
            {      
                Console.WriteLine((sender as Button).Text + " = " + (sender as Button).Tag);
            }
            //Loop through the 10 buttons
            for (int i = 0; i < 10; i++)
            {
                if (i < MyItems.Count )
                {
                    //Transfer Data from list to button
                        ListOfButtons.ElementAt(i).Text = (MyItems.ElementAt(i).Key);
                        ListOfButtons.ElementAt(i).Tag = (MyItems.ElementAt(i).Value);
                    //Set Click Event
                        ListOfButtons.ElementAt(i).Click  += new EventHandler(A_Button_Click);
                }
                else
                {
                    //Hide the button as we've reached the end of the list so have no use for it.
                        ListOfButtons.ElementAt(i).Hide();
                }
            }
        }
