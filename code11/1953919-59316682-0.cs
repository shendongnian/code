        public class DatabaseDetails
        {
            public string DatabaseField { get; set; }
            public string DatabaseValue { get; set; }
        }
        public class Program
        {
            static void Main(string[] args)
            {
                List<DatabaseDetails> SelectOutput = new List<DatabaseDetails>();
                List<string> ControlsInView = new List<string>();
                ControlsInView.Add("txtName");
                ControlsInView.Add("txtPhone");
                ControlsInView.Add("txtAddress");
                ControlsInView.Add("txtPIN");
                SelectOutput.Add(new DatabaseDetails()
                {
                    DatabaseField = "txtName",
                    DatabaseValue = "Ramesh"
                });
                SelectOutput.Add(new DatabaseDetails()
                {
                    DatabaseField = "txtPhone",
                    DatabaseValue = "121212121"
                });
                SelectOutput.Add(new DatabaseDetails()
                {
                    DatabaseField = "txtAddress",
                    DatabaseValue = "XYZ"
                });
                SelectOutput.Add(new DatabaseDetails()
                {
                    DatabaseField = "txtPIN",
                    DatabaseValue = "10001"
                });
                SelectOutput.Add(new DatabaseDetails()
                {
                    DatabaseField = "txtEmail",
                    DatabaseValue = "ramesh@xyz.com"
                });
                foreach (string item in ControlsInView)
                {
                    string DatabaseField = item.ToString();
                    string DatabaseValue = SelectOutput.Where(x => x.DatabaseField == DatabaseField).Select(y=>y.DatabaseValue).FirstOrDefault();
                    Console.WriteLine(DatabaseField + " : " + DatabaseValue);
                }
                Console.ReadKey();
            }
        }
