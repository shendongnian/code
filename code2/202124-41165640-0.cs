    class Employer;
    class Doctor : Employer
    class Administrator : Employer
    class Nurse : Employer
    List<Employer> collection = new List<Employer>();
    collection.Add(new Doctor());
    collection.Add(new Administrator());
    collection.Add(new Doctor());
    collection.Add(new Nurse());
    collection.Add(new Administrator());
    collection = collection.OrderBy(p => p.GetType().Equals(typeof(Nurse))).ThenBy(p => p.GetType().Equals(typeof(Doctor))).ThenBy(p => p.GetType().Equals(typeof(Administrator))).ToList();
