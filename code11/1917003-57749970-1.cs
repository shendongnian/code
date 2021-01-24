    var warmup = context.Messages.First();
    //start timing here...
    var maxId = context.Messages.Select(m => m.Id).Max();
    maxId = context.Messages.Max(m => m.Id);
    var message1 = context.Messages.Where(m => m.Id = context.Messages.Max(x => x.Id)).Single();
    //vs
    var message2 = context.Messages.FromSql("SELECT * FROM messages WHERE id=(SELECT MAX(id) from messages)").Single();
