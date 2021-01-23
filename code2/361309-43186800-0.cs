            try
            {
                context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                //Create empty list to capture Validation error(s)
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(
                        $"{DateTime.Now}: Entity of type \"{eve.Entry.Entity.GetType().Name}\" in state \"{eve.Entry.State}\" has the following validation errors:");
                    outputLines.AddRange(eve.ValidationErrors.Select(ve =>
                        $"- Property: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\""));
                }
                //Write to external file
                File.AppendAllLines(@"c:\temp\dbErrors.txt", outputLines);
                throw;
            }
