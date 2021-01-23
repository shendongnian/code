    using PersonRepository;
    using CvRepository;
    
    public class CvPersonService
    {
       public CvPerson GetHydratedCvPersonFromTwoRepositories()
       {
            var person = personRepository.Find(1); // get a person
            var cv = cvRepository.Find(1); // get a cv
    
            return new CvPerson { ThePerson = person, TheCv = cv };
       }
    }
