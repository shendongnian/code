    using (DatabaseContext dbContext = new DatabaseContext())
            {
                Part part = new Part();
                part.Id = int.Parse(TextBoxID.Text);
                part.Name = TextBoxName.Text;
                part.Image = image;
                dbContext.Part.Add(part);
                dbContext.SaveChanges();
                RefreshPartsList();
            }}
