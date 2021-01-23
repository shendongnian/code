    using System;
    using System.Collections.Generic;
    using System.Text;
    using Newtonsoft.Json;
    using System.IO;
    namespace com.blogspot.jeanjmichel.jsontest.model
    {
        public class Contact
        {
            private Int64 id;
            private String name;
            List<Address> addresses;
            
            public Int64 Id
            {
                set { this.id = value; }
                get { return this.id; }
            }
            
            public String Name
            {
                set { this.name = value; }
                get { return this.name; }
            }
            
            public List<Address> Addresses
            {
                set { this.addresses = value; }
                get { return this.addresses; }
            }
            
            public String ToJSONRepresentation()
            {
                StringBuilder sb = new StringBuilder();
                JsonWriter jw = new JsonTextWriter(new StringWriter(sb));
                jw.Formatting = Formatting.Indented;
                jw.WriteStartObject();
                jw.WritePropertyName("id");
                jw.WriteValue(this.Id);
                jw.WritePropertyName("name");
                jw.WriteValue(this.Name);
                
                jw.WritePropertyName("addresses");
                jw.WriteStartArray();
                
                int i;
                i = 0;
                
                for (i = 0; i < addresses.Count; i++)
                {
                    jw.WriteStartObject();
                    jw.WritePropertyName("id");
                    jw.WriteValue(addresses[i].Id);
                    jw.WritePropertyName("streetAddress");
                    jw.WriteValue(addresses[i].StreetAddress);
                    jw.WritePropertyName("complement");
                    jw.WriteValue(addresses[i].Complement);
                    jw.WritePropertyName("city");
                    jw.WriteValue(addresses[i].City);
                    jw.WritePropertyName("province");
                    jw.WriteValue(addresses[i].Province);
                    jw.WritePropertyName("country");
                    jw.WriteValue(addresses[i].Country);
                    jw.WritePropertyName("postalCode");
                    jw.WriteValue(addresses[i].PostalCode);
                    jw.WriteEndObject();
                }
                
                jw.WriteEndArray();
                
                jw.WriteEndObject();
                
                return sb.ToString();
            }
            
            public Contact()
            {
            }
            
            public Contact(Int64 id, String personName, List<Address> addresses)
            {
                this.id = id;
                this.name = personName;
                this.addresses = addresses;
            }
            
            public Contact(String JSONRepresentation)
            {
                //To do
            }
        }
    }
