        public class Click
        {
            public string ID { get; set; }
            public string Type { get; set; }
            public string Time { get; set; }
            public Click(string ID, string Type, string Time)
            {
                this.ID = ID;
                this.Type = Type;
                this.Time = Time;
            }
        }
