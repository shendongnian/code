	private void Button_Click(object sender, RoutedEventArgs e)
	{
		//this should be done asynchronously - "request" a person
		List<Person> people = new List<Person>();
		PersonService ps = new PersonService();		
		ThreadPool.QueueUserWorkItem(func =>
		{
			for (int i = 0; i < 10; i++)
			{
						people.Add(ps.GetRandomPerson()); //you need to call this on a separate thread or it will lock the ui thread.						
			}									
			Dispatcher.BeginInvoke(() => { Status.Text = "done"; });	//your button click method is now also asynchronous
		});
	}
	
	/*** Helper class ***/		
	
	public class PersonService
    {
        AutoResetEvent sync = new AutoResetEvent(false);
        public Person GetRandomPerson()
        {
            Person person = new Person();
            Contacts contacts = new Contacts();            
            contacts.SearchCompleted += new EventHandler<ContactsSearchEventArgs>(contacts_SearchCompleted);            
            contacts.SearchAsync(String.Empty, FilterKind.None, person);
            sync.WaitOne();
            return person;
        }
        void contacts_SearchCompleted(object sender, ContactsSearchEventArgs e)
        {
            Contact[] allContacts = e.Results.ToArray();
            Contact randomContact = allContacts[new Random().Next(allContacts.Length)];
            Person person = (Person)e.State;
            person.Name = randomContact.DisplayName;
            sync.Set();
        }
    }
	
