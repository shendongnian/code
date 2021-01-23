    public class Snowman : DrawableGameObject
    {
        private Camera  cam = new Camera();
        //Model snowMan;
        //Matrix[] snowManMatrix;
        public Model snowMan {get;set;};
        public Matrix[] snowManMatrix{get;set;};
        protected override void LoadContent()
        {
            //snowMan = Content.Load<Model>( "Models\\snowman" );
            snowManMatrix = new Matrix[ snowMan.Bones.Count ];
            snowMan.CopyAbsoluteBoneTransformsTo( snowManMatrix );
        }
        public void DrawSnowMan(Model model, GameTime gameTime) 
        {
            foreach (ModelMesh mesh in model.Meshes) 
            {
                Matrix world, scale, translation;
   
                scale = Matrix.CreateScale(0.02f, 0.02f, 0.02f);
                translation = Matrix.CreateScale(0.0f, 0.7f, -4.0f);
                world = scale * translation;
             foreach (BasicEffect effect in mesh.Effects)
             {
                effect.World = snowManMatrix[mesh.ParentBone.Index] * world;
                effect.View = cam.viewMatrix;
                effect.Projection = cam.projectionMatrix;
                effect.EnableDefaultLighting();
             }
               mesh.Draw();
             }
        }
        protected override void Draw(GameTime gameTime)
        {
            DrawSnowMan( snowMan, gameTime ); 
        }
    }
