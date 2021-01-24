    public class AddRule : ICommandRule {
        public bool IsMatched(string command) {
            return command == "add";
        }
        public void ExecuteCommand(string command) {
            if (command.Length < 3) {
                Console.WriteLine("Neplatny pocet parametru pro operaci add");
            }
            else
                AddCommand(command, r);
        }
    }
