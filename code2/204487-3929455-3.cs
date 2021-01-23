    public class EntryGrouper : IEquatable<Entry>
    {
        private Entry _entry;
        private string _section;
        private string _page;
        private string _module;
    
        public EntryGrouper(Entry entry, string section, string page, string module)
        {
            _entry = entry;
            _section = section;
            _page = page;
            _module = module;
        }
    
        public string SeriesName
        {
            get
            {
                return String.Format("{0}:{1}:{2}", this.Section, this.Page, this.Module);
            }
        }
    
        public DateTime StartOfWeek
        {
            get
            {
                return _entry.StartOfWeek;
            }
        }
    
        public string Section
        {
            get
            {
                if (_section == "Total" || _section == "All")
                    return _section;
                return _entry.Section;
            }
        }
    
        public string Page
        {
            get
            {
                if (_page == "Total" || _page == "All")
                    return _page;
                return _entry.Page;
            }
        }
    
        public string Module
        {
            get
            {
                if (_module == "Total" || _module == "All")
                    return _module;
                return _entry.Module;
            }
        }
    
        public override bool Equals(object other)
        {
            if (other is Entry)
                return this.Equals((Entry)other);
            return false;
        }
    
        public bool Equals(Entry other)
        {
            if (other == null)
                return false;
            if (!EqualityComparer<DateTime>.Default.Equals(this.StartOfWeek, other.StartOfWeek))
                return false;
            if (!EqualityComparer<string>.Default.Equals(this.Section, other.Section))
                return false;
            if (!EqualityComparer<string>.Default.Equals(this.Page, other.Page))
                return false;
            if (!EqualityComparer<string>.Default.Equals(this.Module, other.Module))
                return false;
            return true;
        }
    
        public override int GetHashCode()
        {
            var hash = 0;
            hash ^= EqualityComparer<DateTime>.Default.GetHashCode(this.StartOfWeek);
            hash ^= EqualityComparer<string>.Default.GetHashCode(this.Section);
            hash ^= EqualityComparer<string>.Default.GetHashCode(this.Page);
            hash ^= EqualityComparer<string>.Default.GetHashCode(this.Module);
            return hash;
        }
    
        public override string ToString()
        {
            var template = "{{ StartOfWeek = {0}, Section = {1}, Page = {2}, Module = {3} }}";
            return String.Format(template, this.StartOfWeek, this.Section, this.Page, this.Module);
        }
    }
