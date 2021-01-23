    internal class Client
    {
        // Class fields and properties.
        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { SetStringValue(ref firstName, value); }
        }
        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { SetStringValue(ref lastName, value); }
        }
        private string homeAddress;
        public string HomeAddress
        {
            get { return homeAddress; }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    homeAddress = value;
                }
                else
                {
                    homeAddress = "No home address";
                }
            }
        }
        private string workAddress;
        public string WorkAddress
        {
            get { return workAddress; }
            set { SetStringValue(ref workAddress, value); }
        }
        private string email;
        public string Email
        {
            get { return email; }
            set { SetStringValue(ref email, value); }
        }
        private long homePhone;
        public long HomePhone
        {
            get { return homePhone; }
            set { SetLongValue(ref homePhone, value); }
        }
        private long cellPhone;
        public long CellPhone
        {
            get { return cellPhone; }
            set { SetLongValue(ref cellPhone, value); }
        }
        // Constructors.
        public Client(string firstName, string lastName, string homeAddress, string workAddress,
            string email, long homePhone, long cellPhone)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.HomeAddress = homeAddress;
            this.WorkAddress = workAddress;
            this.Email = email;
            this.HomePhone = homePhone;
            this.CellPhone = cellPhone;
        }
        // Supporting methods for initialization.
        private void SetStringValue(ref string field, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                field = value;
            }
            else
            {
                throw new NullReferenceException();
            }
        }
        private void SetLongValue(ref long field, long value)
        {
            if (value != 0)
            {
                field = value;
            }
            else
            {
                throw new NotSupportedException();
            }
        }
    }
    internal class ClientDemo
    {
        static void Main(string[] args)
        {
            // Inputs.
            Console.Write("Enter your first name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your home address: ");
            string homeAddress = Console.ReadLine();
            Console.Write("Enter your work address: ");
            string workAddress = Console.ReadLine();
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.Write("Enter your home phone: ");
            long homePhone = long.Parse(Console.ReadLine());
            Console.Write("Enter your cell phone: ");
            long cellPhone = long.Parse(Console.ReadLine());
            // Create client object, assuming that without home address all the fields have data.
            Client myClient = null;
            try
            {
                myClient = new Client
                    (firstName, lastName, homeAddress, workAddress, email, homePhone, cellPhone);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Show result.
            Console.WriteLine();
            if (myClient != null)
            {
                Console.WriteLine(myClient.FirstName);
                Console.WriteLine(myClient.LastName);
                Console.WriteLine(myClient.HomeAddress);
                Console.WriteLine(myClient.WorkAddress);
                Console.WriteLine(myClient.Email);
                Console.WriteLine(myClient.HomePhone);
                Console.WriteLine(myClient.CellPhone);
            }
            Console.WriteLine();
            Console.ReadKey(true);
        }
    }
