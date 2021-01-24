        public void AddNote(NoteViewModel currentNote)
        {
            using(var context = new MyDBContext())
            {
                var currentUser = context.Users.Single(x => x.UserId = currentUserId);
                var note = new Note
                {
                    Text = currentNote.Text,
                    // ... other stuff.
                };
                currentUser.Notes.Add(currentNote);
                 context.SaveChanges();
            }
        }
