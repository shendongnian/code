    public class TransformData 
    {
      public Vector3 position;
      public Quaternion rotation;
      public Vector3 scale;
      public TransformData(Vector3 pos, Quaternion  rot, Vector3  sc)
      {
        position = pos;
        rotation = rot;
        scale = sc;
      }
    }
