    class Privileges {
        public int ID { get; set; }
        public Type Type { get; set;}
        private Privilege m_Privileges;
        public bool AllowRead {
            get { return HasPrivilege(Privilege.Read); }
            set { CheckPrivilege(Privilege.Read, value); }
        }
        public bool AllowAdd {
            get { return HasPrivilege(Privilege.Add); }
            set { CheckPrivilege(Privilege.Add, value); }
        }
        public bool AllowEdit {
            get { return HasPrivilege(Privilege.Edit); }
            set { CheckPrivilege(Privilege.Edit, value); }
        }
        public bool AllowDelete {
            get { return HasPrivilege(Privilege.Delete); }
            set { CheckPrivilege(Privilege.Delete, value); }
        }
        private bool HasPrivilege(Privilege p) {
            return (m_Privileges & p) == p;
        }
        private void CheckPrivilege(Privilege p, bool owns) {
            if (owns)
                m_Privileges = m_Privileges | p;
            else
                m_Privileges = m_Privileges & (~p);
        }
    }
