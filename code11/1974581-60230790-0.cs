            //The interface contract -> Assures these properties are part of base class
            public interface PetInterface
            {
                int petId { get; set; }
                String name { get; set; }
            }
            //base class which defines contract properties of interface PetInterface
            public class Pet : PetInterface
            {
                public int petId { get; set; }
                public String name { get; set; }
            }
            public class Dog: Pet
            {
               //Add dog specific properties/methods
            }
            public class Cat: Pet
            {
              //Add cat specific properties/methods
            }
