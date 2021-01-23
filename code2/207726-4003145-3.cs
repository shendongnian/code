    using StringInterpolation;
    
    namespace StringInterpolationTest {
        class User {
            public string Name { get; set; }
        }
    
        class Ticket {
            public string ID { get; set; }
            public string Priority { get; set; }
        }
    
        class Program {
            static void Main(string[] args) {
                User user = new User();
                user.Name = "Joe";
                Ticket previousTicket = new Ticket();
                previousTicket.ID = "1";
                previousTicket.Priority = "Low";
                Ticket currentTicket = new Ticket();
                currentTicket.ID = "1";
                currentTicket.Priority = "High";
    
                System.Diagnostics.Debug.WriteLine("User: @user, Username: @user.Name, Previous ticket priority: @previousTicket.Priority, New priority: @currentTicket.Priority".Interpolate(
                    new NamedObject("user", user),
                    new NamedObject("previousTicket", previousTicket),
                    new NamedObject("currentTicket", currentTicket)
                ));
            }
        }
    }
