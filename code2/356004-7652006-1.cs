    public class Command {
        public Command(int id, IEnumerable<string> aliases) {
            Id = id;
            Aliases = alias;
        }
        public int Id { get; set; }         
        public IEnumerable<string> Aliases { get; set; }  
    }
    public class Commands {
        public static readonly Command CommandNameHere1(yourIdHere1, yourAliasesHere1);
        public static readonly Command CommandNameHere2(yourIdHere2, yourAliasesHere2);
        //etc.
    }
