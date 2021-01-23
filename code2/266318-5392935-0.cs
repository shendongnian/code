    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Content;
    
    namespace ProjectGame1 
    {     
        public class Ship : DrawableGameComponent // Notice the class now inherits from
        {                                         // DrawableGameComponent
            public Texture2D texture;          
    
            public Ship(Game game)         
                : base(game) // <<---- Don't forget to pass Game to the base constructor
            {         
                this.texture = game.Content.Load<Texture2D>("ship");         
            }     
        } 
    } 
