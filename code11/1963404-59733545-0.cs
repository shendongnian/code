IQueryable<Person> People = new List<Person>
{
    new Person
    {
        PersonId = 1,
        IsMarried = true
    },
    new Person
    {
        PersonId = 2,
        IsMarried = false
    },
}
.AsQueryable();
bool? isMarried = null;
var query = from p in People
            where !isMarried.HasValue || (isMarried.HasValue && p.IsMarried == isMarried.Value)
            select p;
