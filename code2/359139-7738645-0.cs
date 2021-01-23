    class class2
    {
        private Form m_form;
  
        public class2(Form form)
        {
            m_form = form;
        }
        public void DoThreadStuff()
        {
            string value = m_form.GetTextboxContent();
        }
    }
