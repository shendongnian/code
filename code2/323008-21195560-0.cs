    // Abstract factory class that handles the method calls
    public abstract class AbstractFactory<TDto, TObject> : IFactory<TDto, TObject>
    {
        /// <summary>
        /// Create and initialize the object using data from Dto
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public TObject Create(TDto dto)
        {
            TObject obj = CreateInstance(dto);
            Initialize(dto, obj);
            return obj;
        }
        /// <summary>
        /// Create a new instance of the object
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        protected abstract TObject CreateInstance(TDto dto);
        /// <summary>
        /// Initialize the instance of the object (the "polishing")
        /// </summary>
        /// <param name="dto"></param>
        /// <param name="objeto"></param>
        protected abstract void Initialize(TDto dto, TObject objeto);
    }
    // The Fruit is abstract, so is the factory. It don't override the abstract method that will have the "new" statement, just the "polishing" stuff.
    public abstract class FruitFactory<TFuitDto, TFruit> : AbstractFactory<TFruitDto, TFruit>
        where TFruitDto : FruitDto
        where TFruit : Fruit
    {
        protected override void Initialize(TFruitDto dto, TFruit objeto)
        {
           // Do the fruit "polishing" here
        }
    }
    public class AppleFactory<TAppleDto, TApple> : AbstractFactory<TAppleDto, TApple>
        where TAppleDto : AppleDto
        where TApple : Apple
    {
        protected override TApple CreateInstance(TAppleDto dto)
        {
           // Create a new Apple and don't do any "polishing" here (will break reusability)
           return new Apple(dto) as TApple
        }
        protected override void Initialize(TFruitDto dto, TFruit objeto)
        {
           // Do the Apple "polishing" here
           // Call the Fruit "polish"
           base.Initialize(dto, objeto);
        }
    }
