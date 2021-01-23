        public override void Accept(SystemVisitor visitor)
        {
            var visitorAsUser = visitor as UserVisitor;
            if (visitorAsUser != null)
                return this.Accept(UserVisitor);
        }
