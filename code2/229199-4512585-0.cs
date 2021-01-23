      class MyEqualityComparer: IEqualityComparer<Person>
      {
    
        public bool Equals(Person p1, Person p2)
        {
           if (p1.Age == p2.Age)
              return true;
           return false;
        }
    
    
        public int GetHashCode(Person p)
        {
            return p.Id.GetHashCode();
        }
    
      }
