     [Serializable]
        public class Component_Child_fromxna : BaseComponentAutoSerialization<ISceneEntity>
        {
            Vector3 _parentOffset;
            Matrix _ParentMatrixOffset;
            public override void OnUpdate(GameTime gameTime)
            {
                // Get a sceneobject from the ParentObject
                SceneObject sceneObject = (SceneObject)ParentObject;
                // This relies on the position never being at 0,0,0 for setup, so please don't do that
                // or change it with more look ups so that you don't need to rely on a Zero Vector3 :-)
                if (PassThrough.GroupSetupMode || _parentOffset == Vector3.Zero)
                {
                    if (PassThrough.ParentTranslation != Vector3.Zero)
                    {
                        // The old offset - This is just in world space though...
                        _parentOffset = sceneObject.World.Translation - PassThrough.ParentTranslation;
                        // Get the distance between the child and the parent which we keep as the offset
                        // Inversing the ParentMatrix and multiplying it by the childs matrix gives an offset
                        // The offset is stored as a relative xyz, based on the parents object space
                        _ParentMatrixOffset = sceneObject.World * Matrix.Invert(PassThrough.ParentMatrix);
                    }
                }
                else
                {
                    if (_parentOffset != Vector3.Zero)
                    {
                        //Matrix pLocation = Matrix.CreateTranslation(_parentOffset);
                        //sceneObject.World = Matrix.Multiply(pLocation, PassThrough.ParentMatrix);
                        sceneObject.World = Matrix.Multiply(_ParentMatrixOffset, PassThrough.ParentMatrix);
                    }
                }
            }
        }
