            public class Customer
        {
            public string email { get; set; }
            public List<Property> properties { get; set; }
        }
        public class Property
        {
            public string property { get; set; }
            public string value { get; set; }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Customer _c = new Customer();
            _c.email = email.Text;
            _c.properties = new List<Property>();
            _c.properties.Add(new Property{ property = "company", value = company.Text });
            _c.properties.Add(new Property { property = "website", value = website.Text });
            _c.properties.Add(new Property { property = "firstname", value = firstname.Text });
            _c.properties.Add(new Property { property = "lastname", value = lastname.Text });
            _c.properties.Add(new Property { property = "phone", value = phone.Text });
            string json = JsonConvert.SerializeObject(_c, Formatting.Indented);
            outputBox.Text = json;
        }
