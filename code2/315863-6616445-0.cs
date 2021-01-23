    public class FilesStatus
    {
        private string m_thumbnail_url;
        private string m_name;
        private string m_url;
        private int m_size;
        private string m_type;
        private string m_delete_url;
        private string m_delete_type;
        private string m_error;
        private string m_progress;
        public string m_thumbnailurl { get { return m_thumbnail_url; } set { m_thumbnail_url = value; } }
        public string name { get { return m_name; } set { m_name = value; } }
        public string url { get { return m_url; } set { m_url = value; } }
        public int size { get { return m_size; } set { m_size = value; } }
        public string type { get { return m_type; } set { m_type = value; } }
        public string m_deleteurl { get { return m_delete_url; } set { m_delete_url = value; } }
        public string m_deletetype { get { return m_delete_type; } set { m_delete_type = value; } }
        public string error { get { return m_error; } set { m_error = value; } }
        public string progress { get { return m_progress; } set { m_progress = value; } }
    }
