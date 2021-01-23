     public void Merge(this Person _person, Person source)
     {
         _person.Name = source.Name;
         if(_person.Cars !=null)
         {
            _person.Cars.AddRang(source.Cars);
         }
         else
         {
            _person.Cars = source.Cars;
         }
     }
