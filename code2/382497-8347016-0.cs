    class ComplimentUnaryNode : UnaryNode<bool>
    {
        public ComplimentUnaryNode()
        {
            Function = () => !Right.Value;
        }
    }
