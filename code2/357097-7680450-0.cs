                public class Customer
                {
                    public string Name { get; set; }
                    public string Surname { get; set; }
                    public string Address { get; set; }
                    public string Country { get; set; }
                    public string DOB { get; set; }
                    public string MaritalStatus { get; set; }
                    public override string ToString()
                    {
                        return String.Format("{0}{1}{2}",
                            Name.PadRight(1),
                            Surname.PadRight(20),
                            Address.PadRight(50)
                            );
                    }
                }
