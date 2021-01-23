        ((IObjectContextAdapter)this).ObjectContext.ObjectMaterialized += new ObjectMaterializedEventHandler(ObjectMaterialized);
    
    and then the method looks like this:
    
    private void ObjectMaterialized(object sender, ObjectMaterializedEventArgs e)
            {
                Person person = e.Entity as Person;
                if (person != null) // the entity retrieved was a Person
                {
                    if (person.BirthDate.HasValue)
                    {
                        person.BirthDate = DateTime.SpecifyKind(person.BirthDate.Value, DateTimeKind.Utc);
                    }
                    person.LastUpdatedDate = DateTime.SpecifyKind(person.LastUpdatedDate, DateTimeKind.Utc);
                    person.EnteredDate = DateTime.SpecifyKind(person.EnteredDate, DateTimeKind.Utc);
                }
            }
