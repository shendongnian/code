    var showNotes = from r in em.Test
                    where r.Name == getName
                    select new { Name = r.UserName, Notes = r.Note }
    var userNotes = showNotes.Select((x,i) => string.Format("{0}. {1}-{2}", 
                                                            i, 
                                                            x.Notes, 
                                                            x.Name));
    tbShowNote.Text = String.Join(Environment.NewLine, userNotes );
