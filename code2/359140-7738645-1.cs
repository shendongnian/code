    class class2
    {
        private MyForm m_form;
  
        public class2(MyForm form)
        {
            m_form = form;
        }
        public void DoThreadStuff()
        {
            string value = m_form.GetTextboxContent();
        }
    }
