    public class NoteViewModel{    
        private DateTime? m_Modified;
        private string m_ModifiedBy;
        // note that you do not need the DisplayNameAttribute, because the default 
        // display name is the property name
        public DateTime Modified { 
          get { return m_Modified ?? DateTime.Now; } 
        }
        [DisplayName("Modified By")]
        public string ModifiedBy {
          get { return m_ModifiedBy ?? string.Empty; }
          set { 
            if(value!=null) {
                m_ModifiedBy = value;
                m_Modified = DateTime.Now;       
            }
          }
        } 
    }
