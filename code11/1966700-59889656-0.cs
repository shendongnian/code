    Dispatcher.Invoke(() =>
            {
                try
            {
                using (var context = new DataModel.BusinessData())
                {
                    var people= await context.People
                                            .ToListAsync()
                                            .ConfigureAwait(true);
                    foreach (var person in people)
                    {
                        this.People.Add(new PersonItem(person));
                    }
                }
            }
            catch (Exception ex)
            {
               /*throw; This exception will not be available outside.
               Use flag variable for operation success/failure */
            }
            });
