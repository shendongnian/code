      public class FruitEater
      {
         ArrayList<Fruit> myFruit;
         FruitFactory myFruitMaker;
         public FruitEater()
         {
            this.myFruit = new Arraylist();
            this.myFruitMaker = new FruitFactory();
         }
         public static void Main( args[] stuff )
         {
            myFruit.Add( myFruitMaker.Create( FruitType.Orange ));
            myFruit.Add( myFruitMaker.Create( FruitType.Apple ));
            foreach ( Fruit a in myFruit )
            {
               a.eat(); //FINALLY!!!!
            }
         }
      } //FruitEater class
      public class Fruit
      {
         public delegate void PrepareToEatDelegate();
         protected FruitType type;
         protected PrepType prepToEat;
         // pretend we have public properties to get each of these attributes
         // a field to hold what our delegate creates.
         private PrepareToEatDelegate prepMethod;
         // a method to set our delegate-created field
         public void PrepareToEatMethod( PrepareToEatDelegate clientMethod )
         {
            prepMethod = clientMethod;
         }
         public void Eat()
         {
            this.prepMethod();
            // do other fruit eating stuff
         }
	      public Fruit(FruitType myType ,PrepType myPrepType)
	      {
            this.type = myType;
            this.prepToEat = myPrepType;
	      }
      }
      public class FruitFactory
      {
         public FruitFactory() { }
         public Fruit Create( FruitType myType )
         {
            Fruit newFruit = new Fruit (myType ,myPrepType);
            switch ( myType )
            {
               case FruitType.Orange :
                  newFruit.prepType = PrepType.peel;
                  newFruit.PrepareToEatMethod(new Fruit.PrepareToEatDelegate(FruitFactory.PrepareOrange));
                  break;
               case FruitType.Apple :
                  newFruit.prepType = PrepType.core;
                  newFruit.PrepareToEatMethod( new Fruit.PrepareToEatDelegate( FruitFactory.PrepareApple ) );
                  break;
               default :
                  // throw an exception - we don't have that kind defined.
            }
            return newFruit;
         }// Create()
         // we need a prep method for each type of fruit this factory makes
         public static void PrepareOrange()
         {
            // whatever you do
         }
         public static void PrepareApple()
         {
            // apple stuff 
         }
      }// FruitFactory
      public enum FruitType
      {
         Orange
         ,Apple
         ,Grape
      }
      public enum PrepType
      {
         peel
         ,core
         ,pluck
         ,smash
      }
