    public partial class FormManager : Form
    {    
        FormContact contactForm;
        List<Contact> contacts; // Instead of 1 entity, you need a list of entities
    
        public FormManager()
        {
            InitializeComponent();            
            lstBoxAdd.DataSource = contacts;      // Bind the list to the listbox
            lstBoxAdd.DisplayMember = "FullName"; // Add Fullname to Contact class
        }
    
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ControlsDisabled();                   // It's enough to disable here
            contactForm = new FormContact();
    
            if (contactForm.ShowDialog() == DialogResult.OK)
            {                    
                contact = contactForm.contact;    // You need only the Contact object
                contacts.Add(contact); // You add the contact to to bound list
                txtFname.Text = contact.FirstName;
                txtLname.Text = contact.LastName;                 
            }
            ControlsEnabled();                    // Enable even if dialog fails
        }
    
        private void btnEdit_Click(object sender, EventArgs e)
        {            
            ControlsDisabled();
            contact = lstBoxAdd.SelectedItem as Contact; // Retrieve selected Contact
            contactForm = new ContactForm(contact);      // Pass it to the contactForm
    
            if (contactForm.ShowDialog() == DialogResult.OK)
            {
                contact = contactForm.contact;
                txtFname.Text = contact.FirstName;
                txtLname.Text = contact.LastName;                
                //lstBoxAdd.Items.Add(contact.firstname + " " + contact.lastName); --> Not needed
            }
            ControlsEnabled();
        }
    
        private void lstBoxAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstBoxAdd.SelectedIndex != -1) 
            {
                 Contact selectedContact = (Contact)lstBoxAdd.SelectedItem;
                 txtFname.Text = selectedContact.FirstName;
                 txtLname.Text = selectedContact.LastName;    
            }
        }
    }
