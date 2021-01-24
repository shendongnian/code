c#
// capture all the modified contact.Subjects relationships.
// Assuming contacts is some IEnumerable<> of contact.GetType()
var newValues = contacts.Select(c => (contact = c, c.Subjects)).ToList();
// Re-load them all from the database
await _db.Subjects.Where(s => ...).LoadAsync();
// Reset them all again
foreach((var contact, var subjects) in newValues)
   contact.Subjects = subjects;
The trick is building the where clause. If you already have some criteria you used to fetch the contacts, re-use that. eg;
c#
...Where(s => s.Contact.OtherFK == value);
However, personally I wouldn't do it that way. I'd keep track of each records ```EntityState```, Added / Unchanged / Modified / Deleted and re-attach them to the context. Otherwise how are you going to deal with concurrency issues?
