    public class Parent {
    ....
        public void AddChild(Child child) {
            child.Parent = this;
            this.Children.Add(child);
        }
        public void RemoveChild(Child child) {
            child.Parent = null;
            this.Children.Remove(child);
        }
    }
    public class Child {
        public Child(Parent parent) {
            parent.AddChild(this);
            child.Parent = parent;
        }
    }
