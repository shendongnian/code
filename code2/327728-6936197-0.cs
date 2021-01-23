    public class Node
    {
       abstract void print();
    }
    
    public class AddExpression : Node {
        Node Left;
        Node Right;
        virtual void print() {
            Left.Print();
            Console.WriteLine("+");
            Right.Print();
        }
    }
