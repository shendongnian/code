    class UpdateTo : IComparable<UpdateTo>
    {
        public decimal Version { get; private set; }
        public int Order { get; private set; }
        public string Path { get; private set; }
        private const string Prefix = "UpdateTo";
        public UpdateTo(string path)
        {
            /* No error-checking here -- BEWARE!! */
            Path = path;
            string toParse = Path.Substring(Path.IndexOf(Prefix, StringComparison.InvariantCultureIgnoreCase) + Prefix.Length);
            var split = toParse.Split('-');
            Version = decimal.Parse(split[0]);
            Order = split.Length == 2 ? int.Parse(split[1]) : int.MaxValue;
        }
        public int CompareTo(UpdateTo other)
        {
            int versionCompare = Version.CompareTo(other.Version);
            return versionCompare == 0 ? Order.CompareTo(other.Order) : versionCompare;
        }
    }
