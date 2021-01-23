        private IEnumerable<SelectListItem> _statusType;
        [DisplayName("Status")]
        public IEnumerable<SelectListItem> StatusType
        {
            get
            {
                if (_statusType == null) 
                {
                    _statusType = new[] {
                        new SelectListItem { Value = "0", Text = "Release" },
                        new SelectListItem { Value = "1", Text = "Beta" },
                        new SelectListItem { Value = "2", Text = "Alpha" },
                        new SelectListItem { Value = "3", Text = "Draft" },
                   };
                }
                return _statusType;
            }
        }
