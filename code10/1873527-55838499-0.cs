        private void Foo()
        {
            for (int i = 0; i < database.Rows.Count; i1++)
            {
                Button buttonNew = new Button();
                int id = Convert.ToInt32(row["id"]); //i get id elem of my database 
                buttonNew.Tag = id; // store the ID for later retrieval
                buttonNew.Click += ButtonNew_Click;
                // ... add "buttonNew" to something ...
            }
            
        }
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int id = (int)btn.Tag;
            // ... do something with "id" ...
        }
