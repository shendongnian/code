    public class Item
    {
        public Owner Owner { get; private set }
        
        public void SetOwner(Owner owner)
        {
            if(!owner.OwnsItem)
            {
                this.Owner = owner;
            }
            else
            {
                //Do nothing, throw an exception, log a message, ...
            }
        }
    }
    public class Owner
    {
        public bool OwnsItem()
        {
            return ListOfAllItems.Any(item => item.Owner == this);
        }
    }
