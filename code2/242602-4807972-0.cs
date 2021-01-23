    namespace Contact_Interests
    {
        public partial class MainWindowViewModel // : INotifyPropertyChanged
        {
            private ObservableCollection<AggregatedLabel> myAggLabels;
            public ObservableCollection<AggregatedLabel> AggLabels
            {
                get { return myAggLabels; }
            }
            private ObservableCollection<ContactList> myContactLists;
            public IEnumerable<ContactList> ContactLists
            {
                get { return myContactLists; }
            }
            public MainWindowViewModel()
            {
                GetData();
                // Insert code required on object creation below this point.
            }
            public void GetData()
            {
                myAggLabels = new ObservableCollection<AggregatedLabel>();
                myContactLists = new ObservableCollection<ContactList>();
                DB2Connection conn = null;
                try
                {
                    conn = new DB2Connection("XXXX;");
                }
                catch (Exception ex)
                {
                    System.Windows.MessageBox.Show(ex.Message + " " + ex.InnerException);
                }
                //get all contactLists and their labels
                DB2Command command = new DB2Command("SQL SELECT statement");
                command.Connection = conn;
                conn.Open();
                //get all labels from database
                using (DB2DataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        AggregatedLabel aggLabel = new AggregatedLabel();
                        aggLabel.ID = Convert.ToInt32(dr["LABEL_ID"]);
                        aggLabel.Name = dr["LABEL_NAME"].ToString();
                        myAggLabels.Add(aggLabel);
                    }
                }
                //Add unique contactLists to dictionary
                Dictionary<int, ContactList> myContactDictionary = new Dictionary<int, ContactList>();
                using (DB2DataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                       int id = Convert.ToInt32(dr["CONTACT_LIST_ID"]);
                        if (!myContactDictionary.ContainsKey(id))
                        {
                            ContactList contactList = new ContactList();
                            contactList.ContactListID = id;
                            contactList.ContactListName = dr["CONTACT_LIST_NAME"].ToString();
                            contactList.AggLabels = new ObservableCollection<AggregatedLabel>()
                        {
                            new AggregatedLabel()
                            {
                                ID = Convert.ToInt32(dr["LABEL_ID"]),
                                Name = dr["LABEL_NAME"].ToString()
                            }
                        };
                            myContactDictionary.Add(id, contactList);
                        }
                        else
                        {
                            //populate existing contact lists with remaining labels
                            ContactList contactList = myContactDictionary[id];
                            contactList.AggLabels.Add
                            (
                                new AggregatedLabel() 
                                {
                                    ID = Convert.ToInt32(dr["LABEL_ID"]),
                                    Name = dr["LABEL_NAME"].ToString()
                                }
                            );
                        }
                    }
                }
                //add to observable collection      
                foreach (KeyValuePair<int, ContactList> contactKeyValue in myContactDictionary)
                {
                    ContactList contactList = contactKeyValue.Value;
                    myContactLists.Add(contactList);
                }
                conn.Close();        
            }
        }
    }
