    public abstract class Animal { }
    public abstract  class Mammal : Animal { }
    public sealed class Koala : Mammal { }
    public abstract class AnimalDTO<TAnimal, TDTO> where TAnimal : Animal
    {
        public abstract TDTO ConvertToDTO(TAnimal entity);       
    }
    public abstract class MammalDTO<TMammal, TMammalDTO> : AnimalDTO<TMammal, TMammalDTO>
        where TMammal : Mammal
        where TMammalDTO : MammalDTO<TMammal, TMammalDTO>{}
    public sealed class KoalaDTO : MammalDTO<Koala, KoalaDTO>
    {
        public override KoalaDTO ConvertToDTO(Koala entity)
        {
            throw new NotImplementedException();
        }
    }
