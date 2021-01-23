    public class Animal { }
    public class Mammal : Animal { }
    public class Koala : Mammal { }
    public abstract class AnimalDTO<TAnimal, TDTO> where TAnimal : Animal
    {
        public abstract TDTO ConvertToDTO(TAnimal entity);       
    }
    public abstract class MammalDTO<TMammal, TMammalDTO> : AnimalDTO<TMammal, TMammalDTO>
        where TMammal : Mammal
        where TMammalDTO : MammalDTO<TMammal, TMammalDTO>{}
    public class KoalaDTO : MammalDTO<Koala, KoalaDTO>
    {
        public override KoalaDTO ConvertToDTO(Koala entity)
        {
            throw new NotImplementedException();
        }
    }
