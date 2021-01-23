        public void SetPose(Matrix rootTransform, Matrix[] boneAlteration)
        {
            skinningDataValue.BindPose.CopyTo(boneTransforms, 0);
            for (int i = 0; i < boneTransforms.Length; i++)
            {
                boneTransforms[i] = boneAlteration[i] * boneTransforms[i];
            }
            UpdateWorldTransforms(rootTransform);
            UpdateSkinTransforms();
        } 
