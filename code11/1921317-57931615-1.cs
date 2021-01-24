     public class Class1 {
        List<ICommandRule> _rules;
        public Class1() {
            // put all the rules in a list
            _rules = new List<ICommandRule>() { new AddRule() }; //add other rules
        }
        // the method you are executing your commands
        public void MainMethod() {
            string[] command = s.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (command.Length == 0) {
                Console.WriteLine("Neplatny pozadavek");
                return;
            }
            // instead of the switch
            _rules.Find(rule => rule.IsMatched(command[0])).ExecuteCommand(command[0]);
        }
