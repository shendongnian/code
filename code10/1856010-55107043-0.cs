    public class Node {
        public object Data { get; set; }
        public Node NextNode { get; set; }
        public override string ToString() {
            return Data.ToString();
        }
        public Node(object data) {
            Data = data;
        }
        public Node AppendNode(object data) {
            var newNode = new Node(data);
            var current = this;
            while (current.NextNode != null)
                current = current.NextNode;
            current.NextNode = newNode;
            return newNode;
        }
        public Node SetFirstNode(object data) {
            return new Node(data) { NextNode = this };
        }
    }
    class Program {
        static void Main(string[] args) {
            var linkedList = new Node(10);
            linkedList.AppendNode(11);
            linkedList.AppendNode(12);
            linkedList.AppendNode(13);
            linkedList.AppendNode(14);
            linkedList.AppendNode(15);
            linkedList = linkedList.SetFirstNode(20);
        }
    }
