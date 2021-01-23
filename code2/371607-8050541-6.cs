        public class Person
        {
            // This field is internal, it means that all classes in the same module (in the same dll for example) can access to this field.
            // This keyword was introduced for the same reason that the "friend" keyword exists in C++.
            // We need this internal so we can modify it from House class.
            internal House house;
            public House MyHouse
            {
                get { return this.house; }
            }
        }
        public class House :
            System.Collections.ObjectModel.Collection<Person>
        {
            // We shadow the base member, this is faster than default implementation, O(1).
            public new bool Contains(Person person)
            {
                return person != null && person.house == this;
            }
            protected override void RemoveItem(int index)
            {
                Person person = this[index];
                base.RemoveItem(index);
                person.house = null;
            }
            protected override void SetItem(int index, Person item)
            {
                if (item == null)
                    throw new ArgumentNullException("Person is null");
                if (item.house != null)
                    throw new InvalidOperationException("Person already owned by another house");
                Person old = this[index];
                base.SetItem(index, item);
                old.house = null;
                item.house = this;
            }
            protected override void InsertItem(int index, Person item)
            {
                if (item == null)
                    throw new ArgumentNullException("Person is null");
                if (item.house != null)
                    throw new InvalidOperationException("Person already owned by another house");
                base.InsertItem(index, item);
                item.house = this;
            }
            protected override void ClearItems()
            {
                foreach (Person person in this)
                {
                    person.house = null;
                }
                base.ClearItems();
            }
        }
