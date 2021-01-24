        public override void Evaluate(IAsk ask)
        {
            bool result = ask.Question("do you feel good or bad");
            string resultAsString = result ? "yes" : "no";
            Console.WriteLine($"\t- {this.Title}? {resultAsString}");
            if (result) this.Positive.Evaluate(ask);
            else this.Negative.Evaluate(ask);
        }
