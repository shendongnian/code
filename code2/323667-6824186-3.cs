    interface INodePart {
        T SomeValue { get; }
    }
    class NodePart : INodePart {
        T INodePart.SomeValue { get; private set; }
    }
    class Node {
        void AddNodePart(NodePart np) {
            T val = (np as INodePart).SomeValue; //require downcast here.
            ...
        }
    }
