    class CheeseImgVisitor : CheeseVisitor 
    {
        private string src;
        public string Src
        {
            get { return this.src; }
        }
        public override void Visit(Wensleydale cheese)
        {
            this.src = "wensleydale.png";
        }
        public override void Visit(Gouda cheese)
        {
            this.src = "gouda.png";
        }
        public override void Default(Cheese cheese)
        {
            this.src = "generic_cheese.png";
        }
    }
