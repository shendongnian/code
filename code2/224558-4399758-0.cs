    public class ParentFactory {
        public Parent CreateParent(string type) {
            switch(type) {
                case "Child1":
                    return new Child1();
                case "Child2":
                    return new Child2();
                default:
                    throw new ArgumentException("Unexpected type");
            }
        }
    }
