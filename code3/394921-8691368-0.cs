        public bool IsSelected
        {
            get
            {
                return m_fIsSelected;
            }
            set
            {
                if (m_fIsSelected != value)
                {
                    this.HasChanged = true;
                    m_fIsSelected = value;
                }
            }
        }
