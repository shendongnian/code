        //overridden Equals() method from the Object class, determines equality based on order number
        public override bool Equals(object obj)
        {
            bool equal;
            if (this.GetType() != obj.GetType())
                equal = false;
            else
            {
                Order temp = (Order)obj;
                if(OrderNumber == temp.OrderNumber)
                    equal = true;
                else
                    equal = false;
            }
            return equal;
        }
        //overridden GetHashCode() method from Object class, sets the unquie identifier to OrderNumber
        public override int GetHashCode()
        {
            return OrderNumber;
        }
