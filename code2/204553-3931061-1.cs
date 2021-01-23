        private TextBox _txtBxName;
        public TextBox txtBxName {
            get {
                if (_txtBxName == null) {
                    _txtBxName = (TextBox)rptrTest.FindControl("txtBxName");
                }
                return _txtBxName;
            }
        }
