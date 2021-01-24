    public class TabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] fragments;
        private readonly string[] titles;
        public TabsFragmentPagerAdapter(FragmentManager fm, Dictionary<string, Fragment> fragments) : base(fm)
        {
            this.fragments = fragments.Values.ToArray();
            this.titles = fragments.Keys.ToArray();
        }
        public override int Count => fragments.Length;
        private String GetCharSeuenceFromString(string s)
        {
            return new String(s);
        }
        public override Object InstantiateItem(ViewGroup container, int position)
        {
            return base.InstantiateItem(container, position);
        }
        public override void SetPrimaryItem(ViewGroup container, int position, Object @object)
        {
            base.SetPrimaryItem(container, position, @object);
        }
        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }
        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return GetCurrentPageTitle(position);
        }
        private ICharSequence GetCurrentPageTitle(int position)
        {
            return GetCharSeuenceFromString(titles[position]);
        }
    }
