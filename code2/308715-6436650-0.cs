    class Foo {
     public Node SomeProperty {get; set;}
        public void SomeFunction(){
            var node = new Node { children = new List<Node>() };
            var childNode = new Node();
            var childNode2 = new Node();
            node.children.Add(childNode);
            node.children.Add(childNode2);
            SomeProperty = childNode2;
            node.children.Clear();
            // childNode will be garbage collected
            // childNode2 is still used by SomeProperty,
            // so it won't be garbage collected until SomeProperty or the instance
            // of Foo is no longer used.
        }
    }
