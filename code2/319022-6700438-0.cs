        List<Item> itemlist;
        List<Item> newItemList;
        public void main()
        {
            //Find all root items (aka, no parents)
            foreach (Item item in itemlist)
            {
                if (item.Parent == null) getObjects(item.ID, 0);
            }
        }
        public void getObjects(Item me, int deep)
        {
            //Store node
            Console.WriteLine("this is me: " + me.ID);
            Console.WriteLine("I am this many levels deep: " + deep);
            newItemList.Insert(me);
            //Find my children
            foreach (Item item in itemlist)
            {
                if (item.Parent == me.ID) getObjects(item.ID, (deep + 1));
            }
        }
