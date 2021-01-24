public async Task<object> Post([FromBody] Message message)
        {
            using (var context = new DbContext())
            {
                System.Diagnostics.Debug.WriteLine(message);
                context.Messages.Add(message);
                await context.SaveChangesAsync();
            }
        }
Thanks to the comment on on my original post!
