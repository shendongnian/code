    public class Example : MonoBehaviour
    {
        public List<Image> imageList = new List<Image>();
    
        private void OnDrawGizmos()
        {
            var min = Vector3.positiveInfinity;
            var max = Vector3.negativeInfinity;
    
            foreach (var image in imageList)
            {
                if(!image) continue;
    
                // Get the 4 corners in world coordinates
                var v = new Vector3[4];
                image.rectTransform.GetWorldCorners(v);
    
                // update min and max
                foreach (var vector3 in v)
                {
                    min = Vector3.Min(min, vector3);
                    max = Vector3.Max(max, vector3);
                }
            }
    
            // create the bounds
            var bounds = new Bounds();
            bounds.SetMinMax(min, max);
    
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }
    }
    
