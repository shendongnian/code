      static Form2 form2;
        
        public void Send(string body, string name)
            {
        
                form2 = new Form2(body);
                form2.Text = name;
               form2.ShowDialog ();
            } 
