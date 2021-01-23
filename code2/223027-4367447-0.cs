        public class FileCopier : ICopier
        {
           String m_source;
           String m_destiniation;
        
           FileCopier(String source_, String destination_)
           {
                m_source = source_;
                m_destiniation = destiniation_;
           }
        
           public void Copy()
           {
                File.Copy(m_source, m_destiniation, true);
           }
        
           public void DeleteSource()
           {
           }
        
           public void DeleteCestination()
           {
           }
        
      etc...
        }
