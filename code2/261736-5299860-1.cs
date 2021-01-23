        // Force the debugger to skip step through
        [DebuggerHidden()]
        public double GrandTotal
        {
            get
            {
                return (this.Subtotal + this.Tax + this.Shipping);
            }
        }
