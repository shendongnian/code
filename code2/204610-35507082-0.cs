        public class ValidatorResult
        {
            public ValidatorResult()
            {
                this.Failiures = new List<string>();
            }
            public bool IsValid => !this.Failiures.Any();
            public List<string> Failiures { get; set; }
        }
