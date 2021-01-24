        public override string ToString()
        {
            return this.IsEnglish() ? this.English : this.French;
        }
        private bool IsEnglish()
        {
            var cultureName = this.Culture != null ? this.Culture.Name : Thread.CurrentThread.CurrentCulture.Name;
            return cultureName.Equals(Language.English.CultureName, StringComparison.OrdinalIgnoreCase);
        }
