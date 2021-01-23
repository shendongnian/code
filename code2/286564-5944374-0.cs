    foreach (var contact in contacts)
    {
        if (Cancel)
        {
            return;
        }
        ContactProcessor processor = new ContactProcessor(contact);
        processor.Process(contact);
    }
    class ContactProcessor
    {
        public bool Skip { get; set; }
        private readonly Contact contact;
        public ContactProcessor(Contact contact)
        {
            this.contact = contact;
        }
        public void Process()
        {
            if (!this.Skip)
            {
                FooSomething();
            }
            if (!this.Skip)
            {
                BarSomething();
            }
            // Etc...
        }
        publiv void BarSomething()
        {
            // Stuff goes here
            if (this.contact.WTF())
            {
                this.Skip = true;
            }
        }
    }
