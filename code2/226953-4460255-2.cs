    public partial class Group
    {
        public IEnumerable<Group> Descendants()
        {
            return LinqExtensions.Descendants(Children, c => c.Children);
        }
        public IEnumerable<Group> Genealogy()
        {
            Group[] ancestor = new Group[] { this };
            return ancestor.Concat(LinqExtensions.Descendants(Children, c => c.Children));
        }
    }
