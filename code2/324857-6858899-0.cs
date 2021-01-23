    public static class SPListItemExtension
    {
        public static int getIndexByName(this SPListItem item, string name)
        {
            for (int i = 0; i < item.Fields.Count; i++)
            {
                if (item.Fields[i].InternalName.Equals(name))
                {
                    return i;
                }
            }
            return -1;
        }
    
    }
