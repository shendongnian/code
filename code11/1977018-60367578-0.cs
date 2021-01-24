       public void Move_Joint1(double angle1,double angle2)
            {
    
                Transform3DGroup Joint1Group = new Transform3DGroup();
                
    
                Joint1Group.Children.Add(new TranslateTransform3D(new Vector3D(0, 0, 185)));
                Joint1Group.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), angle1)));
    
                Shoulder1.Transform = Joint1Group;
    
                Move_Joint2(angle1,angle2);
    
            }
    
    
     public void Move_Joint2(double angle1,double angle2)
            {
                Transform3DGroup Joint2Group = new Transform3DGroup();
    
                Joint2Group.Children.Add(new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), -90)));
    
                Joint2Group.Children.Add(new TranslateTransform3D(new Vector3D(150, 0, 253)));
    
                RotateTransform3D Joint2Rotation1 = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0, 0, 1), angle1));
                Joint2Rotation1.CenterX = Joint2Group.Transform(new Point3D(0, -150, 0)).X;
                Joint2Rotation1.CenterY = Joint2Group.Transform(new Point3D(0, -150, 0)).Y;
                Joint2Rotation1.CenterZ = Joint2Group.Transform(new Point3D(0, -150, 0)).Z;
                Joint2Group.Children.Add(Joint2Rotation1);
    
                Point3D origin = Joint2Group.Transform(new Point3D(0, 0, -70));
                RotateTransform3D Joint2Rotation = new RotateTransform3D(new AxisAngleRotation3D(new Vector3D(0.1, 0, 0), angle2));
                Joint2Rotation.CenterX = origin.X;
                Joint2Rotation.CenterY = origin.Y;
                Joint2Rotation.CenterZ = origin.Z;
    
                Joint2Group.Children.Add(Joint2Rotation);
    
                Arm1.Transform = Joint2Group;
    
            }
