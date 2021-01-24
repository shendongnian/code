        public virtual LocalizedHtmlString this[string name, params object[] arguments]
        {
            get
            {
                if (name == null)
                {
                    throw new ArgumentNullException(nameof(name));
                }
                return ToHtmlString(_localizer[name], arguments);
            }
        }
