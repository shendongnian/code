    public class HybridGroupUser {
        private User _user;
        public User User {
            get { return _user; }
            set {
                _user = value;
                if (value != null) {
                    uid = value.uid;
                    fname = value.fname;
                    lname = value.lname;
                    email = value.email;
                }
            }
        }
        private GroupUser _GroupUser;
        public GroupUser GroupUser {
            get { return _GroupUser; }
            set {
                _GroupUser = value;
                if (value != null) {
                    uid = value.uid;
                    fname = value.fname;
                    lname = value.lname;
                    email = value.email;
                }
            }
        }
    
        public int? uid { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public string email { get; set; }
    }
