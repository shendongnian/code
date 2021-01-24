    public static class ListOperations {
        public static void InsertNode(ref Node linkedList, object data) {
            linkedList = new Node(data) { NextNode = linkedList };
        }
    }
