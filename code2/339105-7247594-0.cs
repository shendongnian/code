        private bool Body_OnCollision(Fixture fixturea, Fixture fixtureb, Contact contact)
        {
            if(this.IsBeingPlaced)
            {
                _canBePlacedCounter++;
            }
            return true;
        }
        private void Body_OnSeperation(Fixture fixturea, Fixture fixtureb)
        {
            if (this.IsBeingPlaced)
            {
                _canBePlacedCounter--;
            }
        }
