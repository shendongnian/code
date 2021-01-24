    public class Club
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime FoundedOn { get; set; }
        public double Score { get; set; }
        public static Club Parse(string input)
        {            
            // Try to split the string on the comma and
            // validate the result is not null and has 4 parts
            var parts = input?.Split(',');
            if (parts?.Length != 4) return null;
            // Strongly typed variables to hold parsed values
            int id;
            string name = parts[1].Trim();
            DateTime founded;
            double score;
            // Validate the parts of the string
            if (!int.TryParse(parts[0], out id)) return null;
            if (name.Length == 0) return null;
            if (!DateTime.TryParse(parts[2], out founded)) return null;
            if (!double.TryParse(parts[3], out score)) return null;
            // Everything is ok, so return a Club instance with properties set
            return new Club {Id = id, Name = name, FoundedOn = founded, Score = score};
        }
    }
