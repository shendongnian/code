    public class DrawVisitor : FruitVisitor 
       {
          public override void Visit(Apple apple)
          {
             //draw the apple
          }
    
          public override void Visit(Banana banana)
          { 
             // draw the banana
          }
       }
